using System;
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
        public DateTime LastModified { get; set; }
        public bool Published { get; set; }
        public string Introduction { get; set; }

        public List<Message> Messages { get; set; }
        public List<PostCategory> PostCategories { get; set; }

        public void ManageUpdate()
        {
            UpdateUrl();
            LastModified = DateTime.Now;
        }

        public string GetSeoDescription()
        {
            const int maxDescriptionLength = 120;

            var textSize = Introduction.Length > maxDescriptionLength ? maxDescriptionLength : Introduction.Length;
            var correctlyLengthedSeoDescription = Introduction.Substring(0, textSize);

            if (textSize == maxDescriptionLength)
            {
                correctlyLengthedSeoDescription += "...";
            }

            return correctlyLengthedSeoDescription;
        }

        private void UpdateUrl()
        {
            Url = Regex.Replace(Title.ToLower(), @"^[./\s]{1}", "");
            Url = Regex.Replace(Url, @"[\./\s]", "-");
            Url = Regex.Replace(Url, @"--", "-");
            Url = Url.Replace("'", "");
        }
    }
}