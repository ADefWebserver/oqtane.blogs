using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Oqtane.Blogs.Models;
using Oqtane.Blogs.Repository;
using Oqtane.Repository;
using Oqtane.Shared;
using WilderMinds.MetaWeblog;

namespace Oqtane.Blogs
{
    public class MetaWeblogService : Controller, IMetaWeblogProvider
    {
        private readonly IWebHostEnvironment _environment;
        private readonly IConfigurationRoot _config;
        private IHttpContextAccessor _httpContextAccessor;

        private readonly IUserRepository _users;
        private readonly IRoleRepository _roles;
        private readonly IUserRoleRepository _userRoles;

        private readonly UserManager<IdentityUser> _identityUserManager;
        private readonly SignInManager<IdentityUser> _identitySignInManager;

        private readonly IBlogRepository _db;

        public MetaWeblogService(
            IWebHostEnvironment environment,
            IHttpContextAccessor httpContextAccessor,
            IConfigurationRoot config,

            IUserRepository users, IRoleRepository roles, IUserRoleRepository userRoles,

            UserManager<IdentityUser> identityUserManager, 
            SignInManager<IdentityUser> identitySignInManager,

            IBlogRepository Blogs)
        {
            _environment = environment;
            _httpContextAccessor = httpContextAccessor;
            _config = config;

            _users = users;
            _roles = roles;
            _userRoles = userRoles;

            _identityUserManager = identityUserManager;
            _identitySignInManager = identitySignInManager;

            _db = Blogs;
        }

        #region public async Task<UserInfo> GetUserInfoAsync(string key, string username, string password)
        public async Task<UserInfo> GetUserInfoAsync(string key, string username, string password)
        {
            UserInfo objUserInfo = new UserInfo();

            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var Blogger = await _db.Users
            //        .Where(x => x.UserName == username)
            //        .FirstOrDefaultAsync();

            //    objUserInfo.userid = Blogger.Id;
            //    objUserInfo.email = Blogger.Email;
            //    objUserInfo.nickname = Blogger.UserName;
            //    objUserInfo.firstname = "";
            //    objUserInfo.lastname = "";
            //    objUserInfo.url = GetBaseUrl();
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return objUserInfo;
        }
        #endregion

        #region public async Task<BlogInfo[]> GetUsersBlogsAsync(string key, string username, string password)
        public async Task<BlogInfo[]> GetUsersBlogsAsync(string key, string username, string password)
        {
            BlogInfo[] colBlogInfo = new BlogInfo[1];
            colBlogInfo[0] = new BlogInfo();
            var result = await IsValidMetaWeblogUserAsync(username, password);

            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var Blogger = _db.Users
            //        .Where(x => x.UserName == username)
            //        .FirstOrDefault();

            //    if (Blogger != null)
            //    {
            //        colBlogInfo[0].blogid = Blogger.Id;
            //        colBlogInfo[0].blogName = Blogger.UserName ?? "";
            //        colBlogInfo[0].url = GetBaseUrl();
            //    }
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return colBlogInfo;
        }
        #endregion

        #region public async Task<Post> GetPostAsync(string postid, string username, string password)
        public async Task<Post> GetPostAsync(string postid, string username, string password)
        {
            Post objPost = new Post();

            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var Blogger = await _db.Users
            //        .Where(x => x.UserName == username)
            //        .FirstOrDefaultAsync();

            //    var BlogPost = await _db.Blog
            //        .Where(x => x.CreatedBy == username)
            //        .Where(x => x.BlogId.ToString() == postid)
            //        .OrderBy(x => x.CreatedOn).FirstOrDefaultAsync();

            //    objPost.title = BlogPost.Title;

            //    objPost.postid = BlogPost.BlogId;
            //    objPost.dateCreated = BlogPost.CreatedOn;
            //    objPost.userid = Blogger.Id;
            //    objPost.description = BlogPost.Title;
            //    objPost.wp_slug = BlogPost.Title;
            //    objPost.link = $"{GetBaseUrl()}/ViewBlogPost/{BlogPost.BlogId}";
            //    objPost.permalink = $"{GetBaseUrl()}/ViewBlogPost/{BlogPost.BlogId}";
            //    objPost.mt_excerpt = BlogPost.Title;
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return objPost;
        }
        #endregion

        #region public async Task<Post[]> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts)
        public async Task<Post[]> GetRecentPostsAsync(string blogid, string username, string password, int numberOfPosts)
        {
            List<Post> Posts = new List<Post>();

            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var Blogger = await _db.Users
            //        .Where(x => x.UserName == username)
            //        .FirstOrDefaultAsync();

            //    var BlogPosts = await _db.Blog
            //        .Where(x => x.CreatedBy == username)
            //        .Take(numberOfPosts)
            //        .OrderByDescending(x => x.CreatedOn).ToListAsync();

            //    foreach (var item in BlogPosts)
            //    {
            //        Post objPost = new Post();
            //        objPost.title = item.Title;

            //        objPost.postid = item.BlogId;
            //        objPost.dateCreated = item.CreatedOn;
            //        objPost.userid = Blogger.Id;
            //        objPost.description = item.Title;
            //        objPost.wp_slug = item.Title;
            //        objPost.link = $"{GetBaseUrl()}/ViewBlogPost/{item.BlogId}";
            //        objPost.permalink = $"{GetBaseUrl()}/ViewBlogPost/{item.BlogId}";
            //        objPost.mt_excerpt = item.Title;

            //        Posts.Add(objPost);
            //    }
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return Posts.ToArray();
        }
        #endregion

        #region public async Task<string> AddPostAsync(string blogid, string username, string password, Post post, bool publish)
        public async Task<string> AddPostAsync(string blogid, string username, string password, Post post, bool publish)
        {
            string BlogPostID = "";

            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    try
            //    {
            //        Blog objBlogs = new Blog();

            //        objBlogs.BlogId = 0;
            //        objBlogs.CreatedBy = username;

            //        if (post.dateCreated > Convert.ToDateTime("1/1/1900"))
            //        {
            //            objBlogs.CreatedOn =
            //                post.dateCreated;
            //        }
            //        else
            //        {
            //            objBlogs.CreatedOn = DateTime.Now;
            //        }

            //        objBlogs.Title =
            //            post.title;

            //        objBlogs.Content =
            //            post.description;

            //        _db.Add(objBlogs);
            //        _db.SaveChanges();
            //        BlogPostID = objBlogs.BlogId.ToString();

            //        _db.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        throw new Exception(ex.GetBaseException().Message);
            //    }
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return BlogPostID;
        }
        #endregion

        #region public async Task<bool> DeletePostAsync(string key, string postid, string username, string password, bool publish)
        public async Task<bool> DeletePostAsync(string key, string postid, string username, string password, bool publish)
        {
            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var ExistingBlogs =
            //        _db.Blog
            //        .Where(x => x.BlogId == Convert.ToInt32(postid))
            //        .FirstOrDefault();

            //    if (ExistingBlogs != null)
            //    {
            //        _db.Blog.Remove(ExistingBlogs);
            //        _db.SaveChanges();
            //    }
            //    else
            //    {
            //        throw new Exception("Blog not found");
            //    }
            //}
            //else
            //{
            //    throw new Exception("Bad user name or password");
            //}

            return true;
        }
        #endregion

        #region public async Task<bool> EditPostAsync(string postid, string username, string password, Post post, bool publish)
        public async Task<bool> EditPostAsync(string postid, string username, string password, Post post, bool publish)
        {
            //if (await IsValidMetaWeblogUserAsync(username, password))
            //{
            //    var ExistingBlogs = await
            //                        _db.Blog
            //                        .Where(x => x.BlogId == Convert.ToInt32(postid))
            //                        .FirstOrDefaultAsync();

            //    if (ExistingBlogs != null)
            //    {
            //        try
            //        {
            //            if (post.dateCreated > Convert.ToDateTime("1/1/1900"))
            //            {
            //                ExistingBlogs.CreatedOn =
            //                    post.dateCreated;
            //            }

            //            ExistingBlogs.Title =
            //                post.title;

            //            ExistingBlogs.Content =
            //                post.description;

            //            _db.SaveChanges();
            //        }
            //        catch (Exception ex)
            //        {
            //            throw new Exception(ex.GetBaseException().Message);
            //        }
            //    }
            //    else
            //    {
            //        throw new Exception("Bad user name or password");
            //    }
            //}

            return true;
        }
        #endregion

        #region public async Task<MediaObjectInfo> NewMediaObjectAsync(string blogid, string username, string password, MediaObject mediaObject)
        public async Task<MediaObjectInfo> NewMediaObjectAsync(string blogid, string username, string password, MediaObject mediaObject)
        {
            MediaObjectInfo mediaInfo = new MediaObjectInfo();

            if (await IsValidMetaWeblogUserAsync(username, password))
            {
                string fileName = Path.GetFileName(mediaObject.name);

                string PathOnly = Path.Combine(
                    _environment.WebRootPath,
                    "blogs",
                    $"{blogid}",
                    Path.GetDirectoryName(mediaObject.name));

                if (!Directory.Exists(PathOnly))
                {
                    Directory.CreateDirectory(PathOnly);
                }

                string FilePath = Path.Combine(PathOnly, fileName);

                var fileBytes = Convert.FromBase64String(mediaObject.bits);

                if (fileBytes != null)
                {
                    using (MemoryStream ms = new MemoryStream(fileBytes))
                    {
                        Bitmap bitmap = new Bitmap(ms);

                        bitmap.Save(FilePath);
                    }
                }

                mediaInfo.url = $@"{GetBaseUrl()}/blogs/{blogid}/{Path.GetDirectoryName(mediaObject.name).Replace("\\", @"/")}/{fileName}";
            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            return mediaInfo;
        }
        #endregion

        #region ** Not Implemented **
        public async Task<CategoryInfo[]> GetCategoriesAsync(string blogid, string username, string password)
        {
            if (await IsValidMetaWeblogUserAsync(username, password))
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }
        public async Task<int> AddCategoryAsync(string key, string username, string password, NewCategory category)
        {
            if (await IsValidMetaWeblogUserAsync(username, password))
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Page GetPage(string blogid, string pageid, string username, string password)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Page[] GetPages(string blogid, string username, string password, int numPages)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Author[] GetAuthors(string blogid, string username, string password)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public string AddPage(string blogid, string username, string password, Page page, bool publish)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public bool EditPage(string blogid, string pageid, string username, string password, Page page, bool publish)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public bool DeletePage(string blogid, string username, string password, string pageid)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<Page> GetPageAsync(string blogid, string pageid, string username, string password)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<Page[]> GetPagesAsync(string blogid, string username, string password, int numPages)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<Author[]> GetAuthorsAsync(string blogid, string username, string password)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<string> AddPageAsync(string blogid, string username, string password, Page page, bool publish)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<bool> EditPageAsync(string blogid, string pageid, string username, string password, Page page, bool publish)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }

        public Task<bool> DeletePageAsync(string blogid, string username, string password, string pageid)
        {
            if (IsValidMetaWeblogUserAsync(username, password).Result)
            {

            }
            else
            {
                throw new Exception("Bad user name or password");
            }

            throw new Exception("Bad user name or password");
        }
        public Task<Tag[]> GetTagsAsync(string blogid, string username, string password)
        {
            throw new NotImplementedException();
        }
        #endregion

        // Utility


        #region private async Task<bool> IsValidMetaWeblogUserAsync(string username, string password)
        private async Task<bool> IsValidMetaWeblogUserAsync(string username, string password)
        {
            // Get user

            string DatabaseConnectionString = NormalizeConnectionString(_config.GetConnectionString(SettingKeys.ConnectionStringKey));

            IdentityUser identityuser = await _identityUserManager.FindByNameAsync(username);

            if (identityuser != null)
            {
                var result = await _identitySignInManager.CheckPasswordSignInAsync(identityuser, password, false);

                if (result.Succeeded)
                {
                    // Must be an Administrator
                    List<Oqtane.Models.UserRole> userroles = _userRoles.GetUserRoles(Convert.ToInt32(identityuser.Id), 1).ToList();

                    foreach (Oqtane.Models.UserRole userrole in userroles)
                    {
                        if (userrole.Role.Name == RoleNames.Admin)
                        {
                            return true;
                        }
                    }
                    
                    return false;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region public string GetBaseUrl()
        public string GetBaseUrl()
        {
            var request = _httpContextAccessor.HttpContext.Request;

            var host = request.Host.ToUriComponent();

            var pathBase = request.PathBase.ToUriComponent();

            return $"{request.Scheme}://{host}{pathBase}";
        }
        #endregion

        #region ConvertToText
        public static string ConvertToText(string sHTML)
        {
            string sContent = sHTML;
            sContent = sContent.Replace("<br />", Environment.NewLine);
            sContent = sContent.Replace("<br>", Environment.NewLine);
            sContent = FormatText(sContent, true);
            return StripTags(sContent, true);
        }
        #endregion

        #region FormatText
        public static string FormatText(string HTML, bool RetainSpace)
        {
            //Match all variants of <br> tag (<br>, <BR>, <br/>, including embedded space
            string brMatch = "\\s*<\\s*[bB][rR]\\s*/\\s*>\\s*";
            //Replace Tags by replacement String and return mofified string
            return System.Text.RegularExpressions.Regex.Replace(HTML, brMatch, Environment.NewLine);
        }
        #endregion

        #region StripTags
        public static string StripTags(string HTML, bool RetainSpace)
        {
            //Set up Replacement String
            string RepString;
            if (RetainSpace)
            {
                RepString = " ";
            }
            else
            {
                RepString = "";
            }

            //Replace Tags by replacement String and return mofified string
            return System.Text.RegularExpressions.Regex.Replace(HTML, "<[^>]*>", RepString);
        }
        #endregion

        #region private string NormalizeConnectionString(string connectionString)
        private string NormalizeConnectionString(string connectionString)
        {
            var dataDirectory = AppDomain.CurrentDomain.GetData("DataDirectory")?.ToString();
            connectionString = connectionString.Replace("|DataDirectory|", dataDirectory);
            return connectionString;
        } 
        #endregion
    }
}
