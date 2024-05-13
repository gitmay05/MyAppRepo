﻿using System;
using System.ComponentModel.DataAnnotations;

namespace AllinOneApiApplication.Model.Form
{
    public class FormModel
    {
        public long PK_FormId { get; set; }

        [Required(ErrorMessage = "Please Enter FormName")]
        public string FormName { get; set; }

        [Required(ErrorMessage = "Please Enter ControllerName")]
        public string ControllerName { get; set; }

        [Required(ErrorMessage = "Please Enter ActionName")]
        public string ActionName { get; set; }

        [Required(ErrorMessage = "Please Enter ClassName")]
        public string ClassName { get; set; }

        public string Area { get; set; }
        public long FK_ParentId { get; set; }

        [Display(Name = "Parent Name")]
        public string ParentForm { get; set; }

        public bool IsActive { get; set; }
        public long CreatedBy { get; set; }
        public string Status { get; set; }

        // Change CreatedDate data type to DateTime
        public string CreatedDate { get; set; }

        public string UserName { get; set; }
    }
}
