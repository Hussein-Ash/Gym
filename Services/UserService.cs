using AutoMapper;
using e_parliament.Interface;
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Entities;
using EvaluationBackend.Repository;

namespace EvaluationBackend.Services
{
    public interface IUserService
    {
        Task<(UserDto? user, string? error)> Login(LoginForm loginForm);
        Task<(UserDto? user, string? error)> DeleteUser(Guid id, Guid userId);
        Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm);
        Task<(UserDto? UserDto, string? error)> AddAdmin(AddUserFromAdminForm registerForm);
        Task<(UserDto? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid userId);
        Task<(UserDto? user, string? error)> ChangeMyPassword(ChangePasswordForm form, Guid id);
        Task<(List<UserDto>? users, int? totalCount, string? error)> GetAll(UserFilter filter);
        Task<(UserDto? user, string? error)> GetUserById(Guid id);
        // Task<(string? user, string? error)> GetAccessToken(Guid? userId, DateTime? ExpierDate);
    }

    public class UserService : IUserService
    {

        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        // private readonly IHubContext<ChatHubService> hubContext;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService
        // ,IHubContext<ChatHub> hubContext
        )
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
            // this.hubContext = hubContext;
        }

        public async Task<(UserDto? user, string? error)> Login(LoginForm loginForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.UserName.ToLower() == loginForm.UserName.ToLower());
            if (user == null || user.Deleted == true) return (null, "User not found");
            if (loginForm.Password != user.Password) return (null, "Wrong password");
            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _tokenService.CreateToken(userDto);
            return (userDto, null);
        }
        public async Task<(UserDto? user, string? error)> DeleteUser(Guid id, Guid userId)
        {
            var IsAdmin = await _repositoryWrapper.User.GetById(userId);
            if (!(IsAdmin!.Role == UserRole.Admin || IsAdmin.Role == UserRole.SuperAdmin || userId == id))
                return (null, "لايمكنك حذف المستخدم");

            var user = await _repositoryWrapper.User.GetById(id);
            if (user == null || user.Deleted == true) return (null, "User Not Found");


            var Deleting = await _repositoryWrapper.User.SoftDelete(id);
            if (Deleting == null) return (null, "Error Deleting");
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);

        }
        public async Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.ToLower() == registerForm.UserName!.ToLower());
            if (user != null) return (null, "User already exists");
            var newUser = new AppUser
            {
                UserName = registerForm.UserName,
                FullName = registerForm.FullName,
                Password = registerForm.Password,
                Img = registerForm.Img,
                Role = UserRole.User
            };
            await _repositoryWrapper.User.CreateUser(newUser);
            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _tokenService.CreateToken(userDto);
            return (userDto, null);
        }

        public async Task<(UserDto? UserDto, string? error)> AddAdmin(AddUserFromAdminForm AddUserForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.ToLower() == AddUserForm.UserName!.ToLower());
            if (user != null) return (null, "الحساب موجود بالفعل");
            var newUser = new AppUser
            {
                UserName = AddUserForm.UserName,
                FullName = AddUserForm.FullName,
                Password = AddUserForm.Password,
                PhoneNumber = AddUserForm.PhoneNumber,
                Role = AddUserForm.Role
            };
            await _repositoryWrapper.User.CreateUser(newUser);
            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _tokenService.CreateToken(userDto);
            return (userDto, null);
        }



        public async Task<(UserDto? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid userId)
        {
            
            var user = await _repositoryWrapper.User.Get(u => u.Id == userId);
            if (user == null || user.Deleted == true) return (null, "User not found");

            if (user.UserName != updateUserForm.UserName) user.UserName = updateUserForm.UserName;
            if (user.FullName != updateUserForm.FullName) user.FullName = updateUserForm.FullName;
            if (user.PhoneNumber != updateUserForm.PhoneNumber) user.PhoneNumber = updateUserForm.PhoneNumber;
            // if (user.Role != role) user.Role = role;
            // if (user.Password != updateUserForm.Password && user.Password != null) user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserForm.Password);

            await _repositoryWrapper.User.UpdateUser(user);

            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }

        public async Task<(UserDto? user, string? error)> UpdateUserRole(UpdateUserFromAdmin updateUserForm, Guid userId)
        {

            var user = await _repositoryWrapper.User.Get(u => u.Id == userId);
            if (user == null || user.Deleted == true) return (null, "User not found");

            if (user.Role != updateUserForm.Role && updateUserForm.Role != null) user.Role = (UserRole)updateUserForm.Role;

            await _repositoryWrapper.User.UpdateUser(user);

            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }

        public async Task<(UserDto? user, string? error)> ChangeMyPassword(ChangePasswordForm form, Guid id)
        {
            var user = await _repositoryWrapper.User.GetById(id);
            if (form.NewPassword == user!.Password) return (null, "Same Password");
            user!.Password = form.NewPassword;

            var result = await _repositoryWrapper.User.Update(user);
            if (result == null) return (null, "Error Updating Password");

            return (_mapper.Map<UserDto>(user), null);

        }

        public async Task<(UserDto? user, string? error)> GetUserById(Guid id)
        {
            var user = await _repositoryWrapper.User.Get(u => u.Id == id);
            if (user == null || user.Deleted == true) return (null, "User not found");
            var userDto = _mapper.Map<UserDto>(user);
            return (userDto, null);
        }
        public async Task<(List<UserDto>? users, int? totalCount, string? error)> GetAll(UserFilter filter)
        {

            var (users, totalCount) = await _repositoryWrapper.User.GetAll<UserDto>(
            //     x => (filter.FullName == null || x.FullName!.Contains(filter.FullName!)) &&
            //    (filter.Email == null || x.Email!.Contains(filter.Email!)) &&
            //   (filter.Role == null || x.Role == filter.Role),

             filter.PageNumber, filter.PageSize
            );
            return (users, totalCount, null);
        }

        // public async Task<(string? user, string? error)> GetAccessToken(Guid? userId, DateTime? ExpierDate)
        // {
        //     var user = await _repositoryWrapper.User.Get<UserDto>(x => x.Id == userId);

        //     if (ExpierDate < DateTime.UtcNow)
        //         return (null, "Expierd");

        //     var token = _tokenService.CreateToken(user!);
        //     return (token, null);
        // }
    }
}