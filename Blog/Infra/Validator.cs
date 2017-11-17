using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.Infra
{
    public class TestValidatorAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {

        public TestValidatorAttribute()
        {

        }

        public override bool IsValid(object value)
        {
            value = (string)value;
            return true;
        }

    }
}