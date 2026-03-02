using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

[Flags]
public enum Person
{
    None = 0,

    [Display(Name = "Man (19+ years)", Order = 71)]
    Man = 1 << 0, // 1

    [Display(Name = "Woman (19+ years)", Order = 72)]
    Woman = 1 << 1, // 2

    [Display(Name = "Adult (19+ years)", Order = 70)]
    Adult = Man | Woman, // 3

    [Display(Name = "Pregnant Woman (19+ years)", Order = 80)]
    PregnantWoman = 1 << 2 | Woman, // 6

    [Display(Name = "Breastfeeding Woman (19+ years)", Order = 81)]
    BreastfeedingWoman = 1 << 3 | Woman, // 10

    [Display(Name = "Pregnant or Breastfeeding Woman (19+ years)", Order = 82)]
    PregnantOrBreastfeedingWoman = PregnantWoman | BreastfeedingWoman | Woman, // 14

    [Display(Name = "Elderly Woman (65+ years)", Order = 91)]
    ElderlyWoman = 1 << 4, // 16

    [Display(Name = "Elderly Man (65+ years)", Order = 92)]
    ElderlyMan = 1 << 5, // 32

    [Display(Name = "Elderly (65+ years)", Order = 90)]
    Elderly = ElderlyMan | ElderlyWoman, // 48

    [Display(Name = "Infant Boy (0-6 months)", Order = 2)]
    InfantBoy = 1 << 6, // 64

    [Display(Name = "Infant Girl (0-6 months)", Order = 3)]
    InfantGirl = 1 << 7, // 128

    [Display(Name = "Infant (0-6 months)", Order = 1)]
    Infant = InfantBoy | InfantGirl, // 192

    [Display(Name = "Baby Boy (7-12 months)", Order = 11)]
    BabyBoy = 1 << 8, // 256

    [Display(Name = "Baby Girl (7-12 months)", Order = 12)]
    BabyGirl = 1 << 9, // 512

    [Display(Name = "Baby (7-12 months)", Order = 10)]
    Baby = BabyBoy | BabyGirl, // 768

    [Display(Name = "Toddler Boy (1-3 years)", Order = 21)]
    ToddlerBoy = 1 << 10, // 1024

    [Display(Name = "Toddler Girl (1-3 years)", Order = 22)]
    ToddlerGirl = 1 << 11, // 2048

    [Display(Name = "Toddler (1-3 years)", Order = 20)]
    Toddler = ToddlerBoy | ToddlerGirl, // 3072

    [Display(Name = "Child Boy (4-8 years)", Order = 31)]
    ChildBoy = 1 << 12, // 4096

    [Display(Name = "Child Girl (4-8 years)", Order = 32)]
    ChildGirl = 1 << 13, // 8192

    [Display(Name = "Child (4-8 years)", Order = 30)]
    Child = ChildBoy | ChildGirl, // 12288

    [Display(Name = "Kid Boy (9-13 years)", Order = 41)]
    KidBoy = 1 << 14, // 16384

    [Display(Name = "Kid Girl (9-13 years)", Order = 42)]
    KidGirl = 1 << 15, // 32768

    [Display(Name = "Kid (9-13 years)", Order = 40)]
    Kid = KidBoy | KidGirl, // 49152

    [Display(Name = "Teen Boy (14-18 years)", Order = 51)]
    TeenBoy = 1 << 16, // 65536

    [Display(Name = "Teen Girl (14-18 years)", Order = 52)]
    TeenGirl = 1 << 17, // 131072

    [Display(Name = "Teen (14-18 years)", Order = 50)]
    Teen = TeenBoy | TeenGirl, // 196608

    [Display(Name = "Pregnant Teen (14-18 years)", Order = 60)]
    PregnantTeenGirl = 1 << 18 | TeenGirl, // 393216

    [Display(Name = "Breastfeeding Teen (14-18 years)", Order = 61)]
    BreastfeedingTeenGirl = 1 << 19 | TeenGirl, // 655360

    [Display(Name = "Pregnant or Breastfeeding Teen (14-18 years)", Order = 62)]
    PregnantOrBreastfeedingTeenGirl = PregnantTeenGirl | BreastfeedingTeenGirl | TeenGirl, // 917504

    All = Man | Woman | PregnantWoman | BreastfeedingWoman | ElderlyMan | ElderlyWoman
        | InfantBoy | InfantGirl | BabyBoy | BabyGirl | ToddlerBoy | ToddlerGirl | ChildBoy | ChildGirl
        | KidBoy | KidGirl | TeenBoy | TeenGirl | PregnantTeenGirl | BreastfeedingTeenGirl
}