using AutoMapper;
using e_parliament.Interface;
<<<<<<< HEAD
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Entities;
using EvaluationBackend.Repository;
=======
using EvaluationBackend.DATA;
using EvaluationBackend.DATA.DTOs.User;
using EvaluationBackend.Entities;
using EvaluationBackend.Helpers.OneSignal;
using EvaluationBackend.Repository;
using Microsoft.EntityFrameworkCore;
>>>>>>> 6c75216 (Initial commit)

namespace EvaluationBackend.Services
{
    public interface IUserService
    {
        Task<(UserDto? user, string? error)> Login(LoginForm loginForm);
        Task<(UserDto? user, string? error)> DeleteUser(Guid id, Guid userId);
        Task<(UserDto? UserDto, string? error)> Register(RegisterForm registerForm);
<<<<<<< HEAD
        Task<(string? message, string? error)> AddAdmin(AddUserFromAdminForm registerForm);
        Task<(UserDto? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid userId);
        Task<(string? message, string? error)> ChangeMyPassword(ChangePasswordForm form, Guid id);
        Task<(List<UserDto>? users, int? totalCount, string? error)> GetAll(UserFilter filter);
        Task<(UserDto? user, string? error)> GetUserById(Guid id);
=======
        Task<(UserDto? UserDto, string? error)> AddAdmin(AddUserFromAdminForm registerForm);
        Task<(UserDto? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid userId);
        Task<(UserDto? user, string? error)> MyProfile(Guid id);
        Task<(string? message, string? error)> ChangeMyPassword(ChangePasswordForm form, Guid id);
        Task<(List<UserDto>? users, int? totalCount, string? error)> GetAll(UserFilter filter);
        Task<(UserDto? user, string? error)> GetUserById(Guid id);
        Task<(UserDto? user, string? error)> ChangeUserPassword(ChangePasswordForm form, Guid id, Guid userId);
        Task<(UserDto? user, string? error)> AdminUpdateUser(UpdateUserForm updateUserForm, Guid adminId, Guid userId);

>>>>>>> 6c75216 (Initial commit)
        // Task<(string? user, string? error)> GetAccessToken(Guid? userId, DateTime? ExpierDate);
    }

    public class UserService : IUserService
    {

        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
<<<<<<< HEAD
        // private readonly IHubContext<ChatHubService> hubContext;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService
=======
        private readonly DataContext _context;
        // private readonly IHubContext<ChatHubService> hubContext;

        public UserService(IRepositoryWrapper repositoryWrapper, IMapper mapper, ITokenService tokenService
        , DataContext context
>>>>>>> 6c75216 (Initial commit)
        // ,IHubContext<ChatHub> hubContext
        )
        {
            _repositoryWrapper = repositoryWrapper;
            _mapper = mapper;
            _tokenService = tokenService;
<<<<<<< HEAD
=======
            _context = context;
>>>>>>> 6c75216 (Initial commit)
            // this.hubContext = hubContext;
        }

        public async Task<(UserDto? user, string? error)> Login(LoginForm loginForm)
        {
<<<<<<< HEAD
            var user = await _repositoryWrapper.User.Get(u => u.UserName.ToLower() == loginForm.UserName.ToLower());
=======
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.Trim().ToLower() == loginForm.UserName.Trim().ToLower());
>>>>>>> 6c75216 (Initial commit)
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
<<<<<<< HEAD
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
=======
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.Trim().ToLower() == registerForm.UserName!.Trim().ToLower());
            if (user != null) return (null, "User already exists");
            var newUser = new AppUser
            {
                UserName = registerForm.UserName!.Trim(),
                FullName = registerForm.FullName!.Trim(),
                Password = registerForm.Password,
                Img = registerForm.Img,
                Role = UserRole.User,
                PhoneNumber = registerForm.PhoneNumber!.Trim()

            };

            await _repositoryWrapper.User.CreateUser(newUser);
            var sub = await _context.Subscriptions.FirstOrDefaultAsync(x => x.PhoneNumber == newUser.PhoneNumber!.Trim());
            if (sub != null)
            {
                sub.UserId = newUser.Id;
                sub.PlayerPhoto = newUser.Img;
                await _repositoryWrapper.Subscription.Update(sub);
                newUser.SubId = sub.Id;
                await _repositoryWrapper.User.Update(newUser);
                var noti = new Notification
                {
                    UserId = newUser.Id,
                    Title = "الاشتراك",
                    Body = $"تم انشاء اشتراك {sub.Type}"

                };
                await _context.Notifications.AddAsync(noti);
                if (await _context.SaveChangesAsync() <= 0) return (null, "error saving entity");
                OneSignal.SendNoitications(noti, newUser.FullName!);

            }
>>>>>>> 6c75216 (Initial commit)
            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _tokenService.CreateToken(userDto);
            return (userDto, null);
        }

<<<<<<< HEAD
        public async Task<(string? message, string? error)> AddAdmin(AddUserFromAdminForm AddUserForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.ToLower() == AddUserForm.UserName!.ToLower());
=======
        public async Task<(UserDto? UserDto, string? error)> AddAdmin(AddUserFromAdminForm AddUserForm)
        {
            var user = await _repositoryWrapper.User.Get(u => u.UserName!.Trim().ToLower() == AddUserForm.UserName!.Trim().ToLower());
>>>>>>> 6c75216 (Initial commit)
            if (user != null) return (null, "الحساب موجود بالفعل");
            var newUser = new AppUser
            {
                UserName = AddUserForm.UserName,
                FullName = AddUserForm.FullName,
                Password = AddUserForm.Password,
                PhoneNumber = AddUserForm.PhoneNumber,
<<<<<<< HEAD
                Role = AddUserForm.Role
=======
                Role = AddUserForm.Role,
                Img = AddUserForm.Img
>>>>>>> 6c75216 (Initial commit)
            };
            await _repositoryWrapper.User.CreateUser(newUser);
            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _tokenService.CreateToken(userDto);
<<<<<<< HEAD
            return ("User Created", null);
=======
            return (userDto, null);
>>>>>>> 6c75216 (Initial commit)
        }



        public async Task<(UserDto? user, string? error)> UpdateUser(UpdateUserForm updateUserForm, Guid userId)
        {
<<<<<<< HEAD
            
            var user = await _repositoryWrapper.User.Get(u => u.Id == userId);
            if (user == null || user.Deleted == true) return (null, "User not found");

            if (user.UserName != updateUserForm.UserName) user.UserName = updateUserForm.UserName;
            if (user.FullName != updateUserForm.FullName) user.FullName = updateUserForm.FullName;
            if (user.PhoneNumber != updateUserForm.PhoneNumber) user.PhoneNumber = updateUserForm.PhoneNumber;
=======

            var user = await _repositoryWrapper.User.Get(u => u.Id == userId);
            if (user == null || user.Deleted == true) return (null, "User not found");

            if (user.UserName != updateUserForm.UserName && updateUserForm.UserName != null) user.UserName = updateUserForm.UserName;
            if (user.FullName != updateUserForm.FullName && updateUserForm.FullName != null) user.FullName = updateUserForm.FullName;
            if (user.PhoneNumber != updateUserForm.PhoneNumber && updateUserForm.PhoneNumber != null) user.PhoneNumber = updateUserForm.PhoneNumber;
>>>>>>> 6c75216 (Initial commit)
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

        public async Task<(string? message, string? error)> ChangeMyPassword(ChangePasswordForm form, Guid id)
        {
            var user = await _repositoryWrapper.User.GetById(id);
            if (form.NewPassword == user!.Password) return (null, "Same Password");
            user!.Password = form.NewPassword;

            var result = await _repositoryWrapper.User.Update(user);
            if (result == null) return (null, "Error Updating Password");

<<<<<<< HEAD
            return ("New Password Is Set",null );
=======
            return ("New Password Is Set", null);
>>>>>>> 6c75216 (Initial commit)

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
<<<<<<< HEAD
                x => (filter.FullName == null || x.FullName!.Contains(filter.FullName!)) &&
=======
                x => x.Role != UserRole.Admin &&
                 x.Role != UserRole.SuperAdmin &&
                 (filter.FullName == null || x.FullName!.Contains(filter.FullName!)) &&
>>>>>>> 6c75216 (Initial commit)
               (filter.UserName == null || x.UserName!.Contains(filter.UserName!)) &&
              (filter.PhoneNumber == null || x.PhoneNumber!.Contains(filter.PhoneNumber!)),

             filter.PageNumber, filter.PageSize
            );
            return (users, totalCount, null);
        }
<<<<<<< HEAD
=======
        public async Task<(UserDto? user, string? error)> ChangeUserPassword(ChangePasswordForm form, Guid id, Guid userId)
        {
            var user = await _repositoryWrapper.User.GetById(userId);
            var admin = await _repositoryWrapper.User.GetById(id);
            if (admin == null) return (null, "something went wrong");

            if (form.NewPassword == user!.Password) return (null, "Same Password");

            user!.Password = form.NewPassword;
            var result = await _repositoryWrapper.User.Update(user);
            if (result == null) return (null, "Error Updating Password");

            return (_mapper.Map<UserDto>(user), null);

        }

        public async Task<(UserDto? user, string? error)> MyProfile(Guid id)
        {
            var user = await _repositoryWrapper.User.Get<UserDto>(x => x.Id == id);
            return user == null ? (null, "User not found") : (user, null);
        }
        public async Task<(UserDto? user, string? error)> AdminUpdateUser(UpdateUserForm updateUserForm, Guid adminId, Guid userId)
        {
            var admin = await _repositoryWrapper.User.GetById(adminId);
            if (admin == null) return (null, "something went wrong");

            var user = await _repositoryWrapper.User.Get(u => u.Id == userId);
            if (user == null || user.Deleted == true) return (null, "User not found");

            _mapper.Map(updateUserForm, user);
            // if (user.UserName != updateUserForm.UserName&& updateUserForm.UserName != null) user.UserName = updateUserForm.UserName;
            // if (user.FullName != updateUserForm.FullName && updateUserForm.FullName != null) user.FullName = updateUserForm.FullName;
            // if (user.PhoneNumber != updateUserForm.PhoneNumber && updateUserForm.PhoneNumber != null) user.PhoneNumber = updateUserForm.PhoneNumber;
            // if (user.Role != role) user.Role = role;
            // if (user.Password != updateUserForm.Password && user.Password != null) user.Password = BCrypt.Net.BCrypt.HashPassword(updateUserForm.Password);

            var result = await _repositoryWrapper.User.UpdateUser(user);
            if (result == null) return (null, "Error Updating Password");

            var userDto = _mapper.Map<UserDto>(result);
            return (userDto, null);
        }
>>>>>>> 6c75216 (Initial commit)

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