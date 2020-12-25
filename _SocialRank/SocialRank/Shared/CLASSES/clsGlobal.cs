using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.CLASSES
{
    public static class clsGlobal
    {
        public static string gPasswordHash = "AnDr1devITV";
        public static string gSaltKey = "s@lT1Zk3ydevMGZ";
        public static string gVIKey = "@AzzeM81YydevLQJ";

        //live
        public const string gEndpointAddress = "http://andrivr.hopto.org:8000/SocialRankAPI/wsSocialRankAPI.asmx";

        public const string gWebServiceNamespace = "http://andrivr.hopto.org:8000/SocialRankAPI";
        public static int gSoapCallTimeout = 30000;

        public const string gMessageCommandSeperator = "||||/|";

        public const int gCompressIfStringLonger = 100000;

        public static string gDBServer = ".";
        public static string gDBDatabase = "SocialRank";
        public static string gDBUser = "sa";
        public static string gDBPassword = "passNEWm.3";

        public static string gConnectionString = "Server=" + gDBServer + ";Database=" + gDBDatabase + ";User ID=" + gDBUser + "; Password=" + gDBPassword + ";Trusted_Connection=False;Connection Timeout = 30";
        public static string gConnectionStringErrors = "Server=" + gDBServer + ";Database=" + gDBDatabase + "Errors" + ";User ID=" + gDBUser + "; Password=" + gDBPassword + ";Trusted_Connection=False;Connection Timeout = 30";

        public static string gEmailFromAddress = "socialrankapi@gmail.com";
        public static string gSmtpPassword = "passSOC.1";
        public static string gSmtpAddress = "smtp.gmail.com";
        public static int gSmtpPort = 587;
        public static int gSmtpTimeout = 20000;
        public static bool gSmtpUseSSL = true;

        public static string gEmailVerificationAddress = gWebServiceNamespace + "/Home/VerifyEmail?xData=";

        public static string gErrorSQL =
        @"
        CREATE TABLE [dbo].[tblError] (
          [Id] int IDENTITY(1, 1) NOT NULL,
          [Error] varchar(2000) NULL,
          PRIMARY KEY CLUSTERED ([Id])
        );";

        public static string gAppSQL =
        @"
        CREATE TABLE [dbo].[tblUser] (
            [Id] int IDENTITY(1, 1) NOT NULL,
            [Email] varchar(500) COLLATE Latin1_General_CI_AS NULL,
            [Alias] varchar(50) COLLATE Latin1_General_CI_AS NULL,
            [Password] varchar(50) COLLATE Latin1_General_CI_AS NULL,
            [EmailVerified] int CONSTRAINT [DF__tblUser__EmailVe__37A5467C] DEFAULT 0 NULL,
            [CreatedDT] datetime CONSTRAINT [DF__tblUser__Created__38996AB5] DEFAULT getdate() NOT NULL,
            CONSTRAINT [PK__tblUser__3214EC077B5EAF05] PRIMARY KEY CLUSTERED ([Id])
        )
        ON [PRIMARY];

        CREATE TABLE [dbo].[tblInstagramUser] (
            [Id] int IDENTITY(1, 1) NOT NULL,
            [tblUserId] int NOT NULL,
            [01_BasicDisplayAPI] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [01_Client_id] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [01_Redirect_uri] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [01_URI_GetCode] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [01_URI_ResponseAfterGetCode] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [02_URI_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [02_Client_secret] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [02_Code] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [02_S_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [02_S_user_id] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [03_URI_long_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [03_L_access_token] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [03_L_token_type] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [03_L_expires_in] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [04_username] varchar(2000) COLLATE Latin1_General_CI_AS NULL,
            [04_media_count] int NULL,
            [CreatedDT] datetime CONSTRAINT [DF__tblInstag__Creat__3F466844] DEFAULT getdate() NOT NULL,
            CONSTRAINT [PK__tblInsta__3214EC074BC58D9B] PRIMARY KEY CLUSTERED ([Id]),
            CONSTRAINT [tblInstagramUser_fk] FOREIGN KEY ([tblUserId]) 
            REFERENCES [dbo].[tblUser] ([Id]) 
            ON UPDATE CASCADE
            ON DELETE CASCADE
        )
        ON [PRIMARY];

        CREATE TABLE [dbo].[tblInstagramUserMediaID] (
            [Id] int IDENTITY(1, 1) NOT NULL,
            [tblInstagramUserId] int NOT NULL,
            [MediaID] int NULL,
            [CreatedDT] datetime CONSTRAINT [DF__tblInstag__Creat__4316F928] DEFAULT getdate() NOT NULL,
            CONSTRAINT [PK__tblInsta__3214EC07D2380E3E] PRIMARY KEY CLUSTERED ([Id]),
            CONSTRAINT [tblInstagramUserMediaID_fk] FOREIGN KEY ([tblInstagramUserId]) 
            REFERENCES [dbo].[tblInstagramUser] ([Id]) 
            ON UPDATE CASCADE
            ON DELETE CASCADE
        )
        ON [PRIMARY];
        ";
    }
}
