﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangalWeb.Model
{
    public class CityViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "City Name is Required")]
        [StringLength(20)]
        public string CityName { get; set; }

        [Required(ErrorMessage = "Please Select State")]
        public int StateId { get; set; }

        public string CountryName { get; set; }

        public string operation { get; set; }
    }
}
