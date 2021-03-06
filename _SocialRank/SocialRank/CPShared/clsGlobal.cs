﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CPShared
{
    public static class clsGlobal
    {
        //Debugging Flag
        public static bool g_DebugMode = false;


        //When the server changes
        public const string gBaseURI = "http://52.186.136.188";         //http://andrivr.hopto.org
        public const string gBasePort = "80";                         //8000
        public static string g_redirect_uri = "https://52.186.136.188/"; //https://avrdev001.azurewebsites.net/
        //--------------------------------------------------------------------------------------------------------------

        public static string gAppName = "SocialRank";
        public static string gAppPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        public static string gLogRootFolder = @"C:\";
        public static string gLogSubfolder = "Logger";
        public static string gLogFileName = gAppName + "_Log.txt";

        public static string gPasswordHash = "AnDr1devITV";
        public static string gSaltKey = "s@lT1Zk3ydevMGZ";
        public static string gVIKey = "@AzzeM81YydevLQJ";

        //live
        public const string gEndpointAddress = gBaseURI + ":" + gBasePort + "/SocialRankAPI/wsSocialRankAPI.asmx";

        public const string gWebServiceNamespace = gBaseURI + ":" + gBasePort + "/SocialRankAPI";
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

        //Get Short Lived Token from Code
        public static string g_URI_access_token = "https://api.instagram.com/oauth/access_token";
        public static string g_client_id = "1101018996984145";
        public static string g_client_secret = "a3eac22d8a35bb4400e1de27b46a415b";

        //Get Long Lived Token from Short Lived Token
        public static string g_URI_long_access_token = "https://graph.instagram.com/access_token?grant_type=ig_exchange_token&&";

        //User name and Media Count
        public static string g_URI_Me_UsernameAndMediaCount = "https://graph.instagram.com/me?fields=id,username,media_count&access_token=";

        //Link Instagram
        public static string g_BasicDisplayAPI = "https://api.instagram.com/oauth/authorize";
        public static string ssss = g_BasicDisplayAPI + "?client_id=" + g_client_id + "&redirect_uri=" + g_redirect_uri + "&scope = user_profile, user_media&response_type=code";


        public class clsMessages
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public string Button { get; set; }
        }

        public static clsMessages[] gclsMessages =
        {
            
            new clsMessages{ Title="Info", Message="Please use a valid email address.", Button="OK"},
            new clsMessages{ Title="Info", Message="Your passwords do not match.", Button="OK"},
            new clsMessages{ Title="Info", Message="Please complete all the fields.", Button="OK"},
            new clsMessages{ Title="Password Was Reset", Message="Please log in using the new credetials.", Button="OK"},
            new clsMessages{ Title="Invalid Code", Message="The code in invalid.", Button="OK"},
            new clsMessages{ Title="Error", Message="An unknown error has occured.", Button="OK"},
            new clsMessages{ Title="Code Sent", Message="Please check your email and click the 'I Have a Code' button to continue.", Button="OK"},
            new clsMessages{ Title="Account Does Not Exist", Message="The account is not registered.", Button="OK"},
            new clsMessages{ Title="Account Not Verified", Message="The account is not verified. Please activate your account by clicking on the link we have sent to your email address.", Button="OK"},
            new clsMessages{ Title="Account Created", Message="Account created successfully. Please activate your account by clicking on the link we have sent to your email address.", Button="OK"},
            new clsMessages{ Title="Account Already Exist", Message="The email address is already in use.", Button="OK"},
            new clsMessages{ Title="Activation Link Sent", Message="Please activate your account by clicking on the link we have sent to your email address.", Button="OK"},
            new clsMessages{ Title="Login Failed", Message="Your password was incorrect.", Button="OK"}




        };

        public enum gMessages
        {
            EmailInvalid,
            PasswordsDoNotMatch,
            CompleteAllFields,
            PasswordWasReset,
            InvalidCode,
            Error,
            CodeSent,
            AccountDoesNotExist,
            AccountNotVerified,
            AccountCreated,
            AccountAlreadyExist,
            ActivationLinkSent,
            InvalidPassword
        }

        public enum gLogLevel
        {
            TRACE,
            INFO,
            DEBUG,
            WARNING,
            ERROR,
            FATAL
        }


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
            [ResetPasswordCode] varchar(5) NULL,
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
