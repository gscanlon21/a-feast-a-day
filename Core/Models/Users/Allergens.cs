using System.ComponentModel.DataAnnotations;

namespace Core.Models.Users;

/// <summary>
/// More of a food group.
/// Keep this in sync with ADiaryADay's Allergens enum.
/// </summary>
[Flags]
public enum Allergens : long
{
    None = 0,


    [Display(Name = "Animal Milk", GroupName = "Dairy", Order = 1)]
    Milk = 1L << 0, // 1

    [Display(Name = "Cheese", GroupName = "Dairy", Order = 2)]
    Cheese = 1L << 1, // 2

    [Display(Name = "Other Dairy", GroupName = "Dairy", Order = 3)]
    OtherDairy = 1L << 2, // 4

    [Display(Name = "Dairy", GroupName = "Dairy")]
    Dairy = Milk | Cheese | OtherDairy, // 7


    [Display(Name = "Corn", GroupName = "Grains", Order = 1)]
    Corn = 1L << 5, // 32

    [Display(Name = "Oats", GroupName = "Grains", Order = 2)]
    Oats = 1L << 6, // 64

    [Display(Name = "Rice", GroupName = "Grains", Order = 3)]
    Rice = 1L << 7, // 128

    [Display(Name = "Wheat", GroupName = "Grains", Order = 4)]
    Wheat = 1L << 8, // 256

    [Display(Name = "Grains", GroupName = "Grains")]
    Grains = Corn | Oats | Rice | Wheat, // 480


    [Display(Name = "Peanuts", GroupName = "Legumes", Order = 1)]
    Peanuts = 1L << 10, // 1024

    [Display(Name = "Soy Beans", GroupName = "Legumes", Order = 2)]
    Soy = 1L << 11, // 2048

    [Display(Name = "Other Legumes", GroupName = "Legumes", Order = 3)]
    OtherLegumes = 1L << 12, // 4096

    [Display(Name = "Legumes", GroupName = "Legumes")]
    Legumes = Peanuts | Soy | OtherLegumes, // 7168


    [Display(Name = "Beef", GroupName = "Meat", Order = 1)]
    Beef = 1L << 15, // 32768

    [Display(Name = "Pork", GroupName = "Meat", Order = 2)]
    Pork = 1L << 16, // 65536

    [Display(Name = "Poultry", GroupName = "Meat", Order = 3)]
    Poultry = 1L << 17, // 131072

    [Display(Name = "Other Meat", GroupName = "Meat", Order = 4)]
    OtherMeat = 1L << 18, // 262144

    [Display(Name = "Meat", GroupName = "Meat")]
    Meat = Beef | Pork | Poultry | OtherMeat, // 491520


    [Display(Name = "Almonds", GroupName = "Nuts", Order = 1)]
    Almonds = 1L << 20, // 1048576

    [Display(Name = "Tree Nuts", GroupName = "Nuts", Order = 2)]
    TreeNuts = 1L << 21, // 2097152

    [Display(Name = "Nuts", GroupName = "Nuts")]
    Nuts = Almonds | TreeNuts, // 3145728


    [Display(Name = "Sesame", GroupName = "Seeds")]
    Sesame = 1L << 25, // 33554432

    [Display(Name = "Sunflower", GroupName = "Seeds")]
    Sunflower = 1L << 26, // 67108864

    [Display(Name = "Seeds", GroupName = "Seeds")]
    Seeds = Sesame | Sunflower, // 100663296


    [Display(Name = "Fish", GroupName = "Seafood", Order = 1)]
    Fish = 1L << 30, // 1073741824

    [Display(Name = "Shellfish", GroupName = "Seafood", Order = 2)]
    Shellfish = 1L << 31, // 2147483648

    [Display(Name = "Seafood", GroupName = "Seafood")]
    Seafood = Fish | Shellfish, // 3221225472


    [Display(Name = "Eggs")]
    Eggs = 1L << 35, // 34359738368

    [Display(Name = "Nightshades")]
    Nightshades = 1L << 36, // 68719476736

    [Display(Name = "Yeast")]
    Yeast = 1L << 37, // 137438953472
}

/* Swap two food preferences.
do $$
declare 
	BeginAllergens bigint = 224;
 	EndAllergens bigint = 491520;
 	TempAllergens bigint = 999;
begin
	update ingredient set "Allergens" = TempAllergens where "Allergens" = EndAllergens;
	update ingredient set "Allergens" = EndAllergens where "Allergens" = BeginAllergens;
	update ingredient set "Allergens" = BeginAllergens where "Allergens" = TempAllergens;

 update user_food_preference set "Allergen" = TempAllergens where "Allergen" = EndAllergens;
	update user_food_preference set "Allergen" = EndAllergens where "Allergen" = BeginAllergens;
	update user_food_preference set "Allergen" = BeginAllergens where "Allergen" = TempAllergens;
end; $$;
*/
