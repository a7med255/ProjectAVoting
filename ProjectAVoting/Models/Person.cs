using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAVoting.Models;

public partial class Person
{

    [Key]
    [ValidateNever]
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Job { get; set; } = "";
                                                                                                                                                                                                                                                                                                                                        
    public int YearExp { get; set; }

    public int Age { get; set; }

    public string Notes { get; set; } = "";
    public string Votes { get; set; } = ""; 

}
