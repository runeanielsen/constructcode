﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Constructcode.Web.Core.Domain
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public List<Message> Messages { get; set; }
        public List<PostCategory> PostCategories { get; set; }

        public string GetIntroduction()
        {
            const int introductionTextLength = 700;

            var contentWithRemovedHtmlTags = Regex.Replace(Content, "<.*?>", string.Empty);
            contentWithRemovedHtmlTags = Regex.Replace(contentWithRemovedHtmlTags, "&nbsp;", string.Empty);
            contentWithRemovedHtmlTags = Regex.Replace(contentWithRemovedHtmlTags, "&ldquo;", string.Empty);
            contentWithRemovedHtmlTags = Regex.Replace(contentWithRemovedHtmlTags, "&rdquo;", string.Empty);
            contentWithRemovedHtmlTags = Regex.Replace(contentWithRemovedHtmlTags, "&acute;", "´");
            contentWithRemovedHtmlTags = Regex.Replace(contentWithRemovedHtmlTags, "&rsquo;", "'");

            return contentWithRemovedHtmlTags.Substring(0, contentWithRemovedHtmlTags.Length > introductionTextLength ? introductionTextLength : contentWithRemovedHtmlTags.Length);
        }

        public void SetCreatedTime()
        {
            Created = DateTime.Now;
        }

        public void UpdateUrl()
        {
            Url = Title.ToLower().Replace(" ", "-");
            Url = Url.ToLower().Replace(".", "-");
        }
    }
}