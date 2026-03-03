using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

[Flags]
public enum Person
{
    None = 0,

    [Display(Name = "Infant Boy (0-6 months)", Order = 2)]
    InfantBoy = 1 << 0, // 1

    [Display(Name = "Infant Girl (0-6 months)", Order = 3)]
    InfantGirl = 1 << 1, // 2

    [Display(Name = "Infant (0-6 months)", Order = 1)]
    Infant = InfantBoy | InfantGirl, // 3

    [Display(Name = "Baby Boy (7-12 months)", Order = 11)]
    BabyBoy = 1 << 2, // 4

    [Display(Name = "Baby Girl (7-12 months)", Order = 12)]
    BabyGirl = 1 << 3, // 8

    [Display(Name = "Baby (7-12 months)", Order = 10)]
    Baby = BabyBoy | BabyGirl, // 12

    [Display(Name = "Toddler Boy (1-2 years)", Order = 21)]
    ToddlerBoy_1_2 = 1 << 4, // 16

    [Display(Name = "Toddler Girl (1-2 years)", Order = 22)]
    ToddlerGirl_1_2 = 1 << 5, // 32

    [Display(Name = "Toddler (1-2 years)", Order = 20)]
    Toddler_1_2 = ToddlerBoy_1_2 | ToddlerGirl_1_2, // 48

    [Display(Name = "Toddler Boy (2-3 years)", Order = 24)]
    ToddlerBoy_2_3 = 1 << 6, // 64

    [Display(Name = "Toddler Girl (2-3 years)", Order = 25)]
    ToddlerGirl_2_3 = 1 << 7, // 128

    [Display(Name = "Toddler (2-3 years)", Order = 23)]
    Toddler_2_3 = ToddlerBoy_2_3 | ToddlerGirl_2_3, // 192

    [Display(Name = "Child Boy (4-8 years)", Order = 31)]
    ChildBoy = 1 << 8, // 256

    [Display(Name = "Child Girl (4-8 years)", Order = 32)]
    ChildGirl = 1 << 9, // 512

    [Display(Name = "Child (4-8 years)", Order = 30)]
    Child = ChildBoy | ChildGirl, // 768

    [Display(Name = "Kid Boy (9-13 years)", Order = 41)]
    KidBoy = 1 << 10, // 1024

    [Display(Name = "Kid Girl (9-13 years)", Order = 42)]
    KidGirl = 1 << 11, // 2048

    [Display(Name = "Kid (9-13 years)", Order = 40)]
    Kid = KidBoy | KidGirl, // 3072

    [Display(Name = "Teen Boy (14-18 years)", Order = 51)]
    TeenBoy = 1 << 12, // 4096

    [Display(Name = "Teen Girl (14-18 years)", Order = 52)]
    TeenGirl = 1 << 13, // 8192

    [Display(Name = "Teen (14-18 years)", Order = 50)]
    Teen = TeenBoy | TeenGirl, // 12288

    [Display(Name = "Pregnant Teen (14-18 years)", Order = 53)]
    PregnantTeenGirl = 1 << 14 | TeenGirl, // 24576

    [Display(Name = "Breastfeeding Teen (14-18 years)", Order = 54)]
    BreastfeedingTeenGirl = 1 << 15 | TeenGirl, // 40960

    [Display(Name = "Pregnant or Breastfeeding Teen (14-18 years)", Order = 55)]
    PregnantOrBreastfeedingTeenGirl = PregnantTeenGirl | BreastfeedingTeenGirl | TeenGirl, // 57344

    [Display(Name = "Young Man (19-30 years)", Order = 61)]
    YoungMan = 1 << 16, // 65536

    [Display(Name = "Young Woman (19-30 years)", Order = 62)]
    YoungWoman = 1 << 17, // 131072

    [Display(Name = "Young Adult (19-30 years)", Order = 60)]
    YoungAdult = YoungMan | YoungWoman, // 196608

    [Display(Name = "Pregnant Young Woman (19-30 years)", Order = 63)]
    PregnantYoungWoman = 1 << 18 | YoungWoman, // 393216

    [Display(Name = "Breastfeeding Young Woman (19-30 years)", Order = 64)]
    BreastfeedingYoungWoman = 1 << 19 | YoungWoman, // 655360

    [Display(Name = "Pregnant or Breastfeeding Young Woman (19-30 years)", Order = 65)]
    PregnantOrBreastfeedingYoungWoman = PregnantYoungWoman | BreastfeedingYoungWoman | YoungWoman, // 917504

    [Display(Name = "Man (31-50 years)", Order = 71)]
    Man = 1 << 20, // 1048576

    [Display(Name = "Woman (31-50 years)", Order = 72)]
    Woman = 1 << 21, // 2097152

    [Display(Name = "Adult (31-50 years)", Order = 70)]
    Adult = Man | Woman, // 3145728

    [Display(Name = "Pregnant Woman (31-50 years)", Order = 73)]
    PregnantWoman = 1 << 22 | Woman, // 6291456

    [Display(Name = "Breastfeeding Woman (31-50 years)", Order = 74)]
    BreastfeedingWoman = 1 << 23 | Woman, // 10485760

    [Display(Name = "Pregnant or Breastfeeding Woman (31-50 years)", Order = 75)]
    PregnantOrBreastfeedingWoman = PregnantWoman | BreastfeedingWoman | Woman, // 14680064

    [Display(Name = "Middle Age Woman (51-70 years)", Order = 81)]
    MiddleAgeWoman = 1 << 24, // 16777216

    [Display(Name = "Middle Age Man (51-70 years)", Order = 82)]
    MiddleAgeMan = 1 << 25, // 33554432

    [Display(Name = "Middle Age (51-70 years)", Order = 80)]
    MiddleAge = MiddleAgeMan | MiddleAgeWoman, // 50331648

    [Display(Name = "Elderly Woman (71+ years)", Order = 91)]
    ElderlyWoman = 1 << 26, // 67108864

    [Display(Name = "Elderly Man (71+ years)", Order = 92)]
    ElderlyMan = 1 << 27, // 134217728

    [Display(Name = "Elderly (71+ years)", Order = 90)]
    Elderly = ElderlyMan | ElderlyWoman, // 201326592

    All = InfantBoy | InfantGirl | BabyBoy | BabyGirl 
        | ToddlerBoy_1_2 | ToddlerGirl_1_2 | ToddlerBoy_2_3 | ToddlerGirl_2_3
        | ChildBoy | ChildGirl | KidBoy | KidGirl 
        | TeenBoy | TeenGirl | PregnantTeenGirl | BreastfeedingTeenGirl
        | YoungMan | YoungWoman | PregnantYoungWoman | BreastfeedingYoungWoman
        | Man | Woman | PregnantWoman | BreastfeedingWoman
        | MiddleAgeMan | MiddleAgeWoman | ElderlyMan | ElderlyWoman
}