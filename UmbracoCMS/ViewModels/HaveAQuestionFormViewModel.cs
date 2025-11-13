using System.ComponentModel.DataAnnotations;

namespace UmbracoCMS.ViewModels;

public class HaveAQuestionFormViewModel
{
  [Required(ErrorMessage = "Name is required")]
  [Display(Name = "Name")]
  public string Name { get; set; } = null!;

  [Required(ErrorMessage = "Email is required")]
  [Display(Name = "Email address")]
  [RegularExpression(@"^(([^<>()\]\\.,;:\s@\""]+(\.[^<>()\]\\.,;:\s@\""]+)*)|("".+""))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid email address")]
  public string Email { get; set; } = null!;

  [Required(ErrorMessage = "Question is required")]
  [Display(Name = "Question")]
  public string Question { get; set; } = null!;
}
