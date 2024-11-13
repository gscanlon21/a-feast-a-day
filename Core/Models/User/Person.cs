using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Person
{
    None = 0,

    [Display(Name = "Man")]
    Man = 1 << 0, // 1

    [Display(Name = "Woman")]
    Woman = 1 << 1, // 2

    [Display(Name = "Adult")]
    Adult = Man | Woman, // 3

    [Display(Name = "Pregnant Woman")]
    PregnantWoman = 1 << 2 | Woman, // 6

    [Display(Name = "Breastfeeding Woman")]
    BreastfeedingWoman = 1 << 3 | Woman, // 10

    [Display(Name = "Pregnant or Breastfeeding Woman")]
    PregnantOrBreastfeedingWoman = PregnantWoman | BreastfeedingWoman | Woman, // 14

    [Display(Name = "Teen Boy")]
    TeenBoy = 1 << 4, // 16

    [Display(Name = "Teen Girl")]
    TeenGirl = 1 << 5, // 32

    [Display(Name = "Teen")]
    Teens = TeenGirl | TeenBoy, // 48

    [Display(Name = "Elderly Man")]
    ElderlyMan = 1 << 6, // 64

    [Display(Name = "Elderly Woman")]
    ElderlyWoman = 1 << 7, // 128

    [Display(Name = "Elderly")]
    Elderly = ElderlyMan | ElderlyWoman, // 192

    All = Man | Woman | ElderlyMan | ElderlyWoman | PregnantWoman | BreastfeedingWoman | TeenGirl | TeenBoy,
}