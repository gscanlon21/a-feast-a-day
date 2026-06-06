using System.ComponentModel.DataAnnotations;

namespace Core.Models.Nutrients;

[Flags]
public enum Person
{
    None = 0,

    [Display(Name = "Male (0-6 months)", Order = 1)]
    Male_0_6_Months = 1 << 0, // 1

    [Display(Name = "Female (0-6 months)", Order = 12)]
    Female_0_6_Months = 1 << 1, // 2

    [Display(Name = "Male (7-12 months)", Order = 2)]
    Male_7_12_Months = 1 << 2, // 4

    [Display(Name = "Female (7-12 months)", Order = 13)]
    Female_7_12_Months = 1 << 3, // 8

    [Display(Name = "Male (1 years)", Order = 3)]
    Male_1_1_Years = 1 << 4, // 16

    [Display(Name = "Female (1 years)", Order = 14)]
    Female_1_1_Years = 1 << 5, // 32

    [Display(Name = "Male (2-3 years)", Order = 4)]
    Male_2_3_Years = 1 << 6, // 64

    [Display(Name = "Female (2-3 years)", Order = 15)]
    Female_2_3_Years = 1 << 7, // 128

    [Display(Name = "Male (4-8 years)", Order = 5)]
    Male_4_8_Years = 1 << 8, // 256

    [Display(Name = "Female (4-8 years)", Order = 16)]
    Female_4_8_Years = 1 << 9, // 512

    [Display(Name = "Male (9-13 years)", Order = 6)]
    Male_9_13_Years = 1 << 10, // 1024

    [Display(Name = "Female (9-13 years)", Order = 17)]
    Female_9_13_Years = 1 << 11, // 2048

    [Display(Name = "Male (14-18 years)", Order = 7)]
    Male_14_18_Years = 1 << 12, // 4096

    [Display(Name = "Female (14-18 years)", Order = 18)]
    Female_14_18_Years = 1 << 13, // 8192

    [Display(Name = "Pregnant (14-18 years)", Order = 23)]
    Pregnant_14_18_Years = 1 << 14 | Female_14_18_Years, // 24576

    [Display(Name = "Lactating (14-18 years)", Order = 26)]
    Lactating_14_18_Years = 1 << 15 | Female_14_18_Years, // 40960

    [Display(Name = "Male (19-30 years)", Order = 8)]
    Male_19_30_Years = 1 << 16, // 65536

    [Display(Name = "Female (19-30 years)", Order = 19)]
    Female_19_30_Years = 1 << 17, // 131072

    [Display(Name = "Pregnant (19-30 years)", Order = 24)]
    Pregnant_19_30_Years = 1 << 18 | Female_19_30_Years, // 393216

    [Display(Name = "Lactating (19-30 years)", Order = 27)]
    Lactating_19_30_Years = 1 << 19 | Female_19_30_Years, // 655360

    [Display(Name = "Male (31-50 years)", Order = 9)]
    Male_31_50_Years = 1 << 20, // 1048576

    [Display(Name = "Female (31-50 years)", Order = 20)]
    Female_31_50_Years = 1 << 21, // 2097152

    [Display(Name = "Pregnant (31-50 years)", Order = 25)]
    Pregnant_31_50_Years = 1 << 22 | Female_31_50_Years, // 6291456

    [Display(Name = "Lactating (31-50 years)", Order = 28)]
    Lactating_31_50_Years = 1 << 23 | Female_31_50_Years, // 10485760

    [Display(Name = "Male (51-70 years)", Order = 10)]
    Male_51_70_Years = 1 << 24, // 16777216

    [Display(Name = "Female (51-70 years)", Order = 21)]
    Female_51_70_Years = 1 << 25, // 33554432

    [Display(Name = "Male (71+ years)", Order = 11)]
    Male_71_XX_Years = 1 << 26, // 67108864

    [Display(Name = "Female (71+ years)", Order = 22)]
    Female_71_XX_Years = 1 << 27, // 134217728

    All = Male_0_6_Months | Female_0_6_Months
        | Male_7_12_Months | Female_7_12_Months
        | Male_1_1_Years | Female_1_1_Years
        | Male_2_3_Years | Female_2_3_Years
        | Male_4_8_Years | Female_4_8_Years
        | Male_9_13_Years | Female_9_13_Years
        | Male_14_18_Years | Female_14_18_Years | Pregnant_14_18_Years | Lactating_14_18_Years
        | Male_19_30_Years | Female_19_30_Years | Pregnant_19_30_Years | Lactating_19_30_Years
        | Male_31_50_Years | Female_31_50_Years | Pregnant_31_50_Years | Lactating_31_50_Years
        | Male_51_70_Years | Female_51_70_Years
        | Male_71_XX_Years | Female_71_XX_Years
}
