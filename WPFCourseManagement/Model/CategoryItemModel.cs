﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFCourseManagement.Model
{
    public class CategoryItemModel
    {
        public CategoryItemModel(string name, bool state=false)
        {
            this.CategoryName = name;
            this.IsSelected = state;
        }
        public bool IsSelected { get; set; }
        public string  CategoryName { get; set; }
    }
}
