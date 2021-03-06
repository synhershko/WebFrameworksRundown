﻿using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace SampleWebApp.Common.Models
{
    public class Question
    {
        public Question()
        {
            CreatedOn = DateTimeOffset.UtcNow;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTimeOffset CreatedOn { get; set; }

        [XmlIgnore]
        public ICollection<string> Tags { get; set; }
        public string CreatedBy { get; set; }
        
        public int Answers { get; set; }
        public int Comments { get; set; }
        public int UpVoteCount { get; set; }
        public int DownVoteCount { get; set; }
        public int FavoriteCount { get; set; }
        public int ViewsCount { get; set; }
    }
}
