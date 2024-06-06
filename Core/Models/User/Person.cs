
using System.ComponentModel.DataAnnotations;

namespace Core.Models.User;

[Flags]
public enum Person
{
    [Display(Name = "")]
    None = 0,

    [Display(Name = "Men")]
    Men = 1 << 0, // 1

    [Display(Name = "Women")]
    Women = 1 << 1, // 2

    [Display(Name = "Young Adult")]
    YoungAdult = Men | Women, // 3

    [Display(Name = "Pregnant Women")]
    PregnantWomen = 1 << 2 | Women, // 6

    [Display(Name = "Breastfeeding Women")]
    BreastfeedingWomen = 1 << 3 | Women, // 10

    [Display(Name = "Pregnant or Breastfeeding Women")]
    PregnantOrBreastfeedingWomen = PregnantWomen | BreastfeedingWomen | Women, // 14

    [Display(Name = "Teen Boys")]
    TeenBoys = 1 << 4, // 16

    [Display(Name = "Teen Girls")]
    TeenGirls = 1 << 5, // 32

    [Display(Name = "Teens")]
    Teens = TeenGirls | TeenBoys, // 48

    [Display(Name = "Elderly Men")]
    ElderlyMen = 1 << 6, // 64

    [Display(Name = "Elderly Women")]
    ElderlyWomen = 1 << 7, // 128

    [Display(Name = "Elderly")]
    Elderly = ElderlyMen | ElderlyWomen,

    [Display(Name = "Adult")]
    Adult = Men | Women | ElderlyMen | ElderlyWomen,

    [Display(Name = "All")]
    All = Men | Women | ElderlyMen | ElderlyWomen | PregnantWomen | BreastfeedingWomen | TeenGirls | TeenBoys,
}