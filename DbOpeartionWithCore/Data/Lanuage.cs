﻿namespace DbOpeartionWithCore.Data
{
    public class Lanuage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
