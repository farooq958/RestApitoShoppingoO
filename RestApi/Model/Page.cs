﻿namespace RestApi.Model
{
    public class Page
    {

        public int Id { get; set; }
       
        public string Title { get; set; }
        public string Slug { get; set; }

        public string Content { get; set; }
        public int Sorting { get; set; }
    }
}
