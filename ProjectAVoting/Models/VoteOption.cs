using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectAVoting.Models;

public partial class VoteOption
{

    [Key]
    public int Id { get; set; }

    public string Votes { get; set; } = "";

}
