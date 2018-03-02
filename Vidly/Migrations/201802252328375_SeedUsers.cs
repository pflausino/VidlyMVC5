namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'08367700-b516-4326-bd6a-783c6ae4e281', N'admin@vidly.com', 0, N'AAxJ4K4AEYaBhzGF2PUQa2LOgui2A+/H16COfu+3sDdZ1X/3bergfixebkxASc0zow==', N'e3a85b21-f21f-442d-94b6-c6ebf926c658', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'1ff01cfb-b942-4ccb-af01-5e3de754caaa', N'gest@vidly.com', 0, N'AEzo2C+aZKcPSDj1ByL+1hHCLLGeDd/pXyNmBeSjjYEoiLv+q7bboSx6WdXW/NfarA==', N'b98abd31-900e-451d-b8f4-db6b8ccd3a64', NULL, 0, 0, NULL, 1, 0, N'gest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'9320ca76-1eab-421b-b30e-a18645cfac46', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'08367700-b516-4326-bd6a-783c6ae4e281', N'9320ca76-1eab-421b-b30e-a18645cfac46')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
