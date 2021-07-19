using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace rygio.Domain.AppData
{
    public class User : BaseEntity
    {
        [Column(TypeName = "nvarchar(128)")]
        public string FacebookId { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Username { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Phone { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Email { get; set; }
        [Column(TypeName = "nvarchar(128)")]
        public string Photo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public DateTime? LoginFailedDate { get; set; }
        public int LoginFailedCount { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsPhoneConfirmed { get; set; }
        public DateTime? EmailConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string EmailConfirmationCode { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string ResetPasswordCode { get; set; }
        public DateTime? PhoneConfirmedDate { get; set; }
        [Column(TypeName = "nvarchar(64)")]
        public string PhoneConfirmationCode { get; set; }
        public DateTime? ResetPasswordRequestDate { get; set; }
        public int ResetPasswordCount { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string MobileDeviceToken { get; set; }
        [Column(TypeName = "nvarchar(255)")]
        public string WebDeviceToken { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<Experience> Experiences { get; set; }
        public IEnumerable<ExperienceMember> ExperienceMembers { get; set; }
        public IEnumerable<Collectable> Collectables { get; set; }
        public IEnumerable<RegionResident> RegionMembers { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
        public IEnumerable<Reply> Replies { get; set; }
        public IEnumerable<BankAccount> BankAccounts { get; set; }
        public IEnumerable<DebitCard> DebitCards { get; set; }
        public IEnumerable<RefreshToken> RefreshTokens { get; set; }


    }
}
