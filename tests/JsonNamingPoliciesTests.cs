using System.Text.Json;
using Xunit;

namespace Yoh.Text.Json.NamingPolicies.Tests
{
    public class JsonNamingPoliciesTests
    {
        [Theory]
        [InlineData("XMLHttpRequest", "xml_http_request")]
        [InlineData("camelCase", "camel_case")]
        [InlineData("CamelCase", "camel_case")]
        [InlineData("snake_case", "snake_case")]
        [InlineData("SNAKE_CASE", "snake_case")]
        [InlineData("kebab-case", "kebab_case")]
        [InlineData("KEBAB-CASE", "kebab_case")]
        [InlineData("double  space", "double_space")]
        [InlineData("double__underscore", "double_underscore")]
        [InlineData("abc", "abc")]
        [InlineData("abC", "ab_c")]
        [InlineData("aBc", "a_bc")]
        [InlineData("aBC", "a_bc")]
        [InlineData("ABc", "a_bc")]
        [InlineData("ABC", "abc")]
        [InlineData("abc123def456", "abc123def456")]
        [InlineData("abc123Def456", "abc123_def456")]
        [InlineData("abc123DEF456", "abc123_def456")]
        [InlineData("ABC123DEF456", "abc123def456")]
        [InlineData("ABC123def456", "abc123def456")]
        [InlineData("Abc123def456", "abc123def456")]
        [InlineData("  abc", "abc")]
        [InlineData("abc  ", "abc")]
        [InlineData("  abc  ", "abc")]
        [InlineData("  abc def  ", "abc_def")]
        public void SnakeLowerCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.SnakeCaseLower.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "XML_HTTP_REQUEST")]
        [InlineData("camelCase", "CAMEL_CASE")]
        [InlineData("CamelCase", "CAMEL_CASE")]
        [InlineData("snake_case", "SNAKE_CASE")]
        [InlineData("SNAKE_CASE", "SNAKE_CASE")]
        [InlineData("kebab-case", "KEBAB_CASE")]
        [InlineData("KEBAB-CASE", "KEBAB_CASE")]
        [InlineData("double  space", "DOUBLE_SPACE")]
        [InlineData("double__underscore", "DOUBLE_UNDERSCORE")]
        [InlineData("abc", "ABC")]
        [InlineData("abC", "AB_C")]
        [InlineData("aBc", "A_BC")]
        [InlineData("aBC", "A_BC")]
        [InlineData("ABc", "A_BC")]
        [InlineData("ABC", "ABC")]
        [InlineData("abc123def456", "ABC123DEF456")]
        [InlineData("abc123Def456", "ABC123_DEF456")]
        [InlineData("abc123DEF456", "ABC123_DEF456")]
        [InlineData("ABC123DEF456", "ABC123DEF456")]
        [InlineData("ABC123def456", "ABC123DEF456")]
        [InlineData("Abc123def456", "ABC123DEF456")]
        [InlineData("  ABC", "ABC")]
        [InlineData("ABC  ", "ABC")]
        [InlineData("  ABC  ", "ABC")]
        [InlineData("  ABC def  ", "ABC_DEF")]
        public void SnakeUpperCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.SnakeCaseUpper.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "xml-http-request")]
        [InlineData("camelCase", "camel-case")]
        [InlineData("CamelCase", "camel-case")]
        [InlineData("snake_case", "snake-case")]
        [InlineData("SNAKE_CASE", "snake-case")]
        [InlineData("kebab-case", "kebab-case")]
        [InlineData("KEBAB-CASE", "kebab-case")]
        [InlineData("double  space", "double-space")]
        [InlineData("double__underscore", "double-underscore")]
        [InlineData("abc", "abc")]
        [InlineData("abC", "ab-c")]
        [InlineData("aBc", "a-bc")]
        [InlineData("aBC", "a-bc")]
        [InlineData("ABc", "a-bc")]
        [InlineData("ABC", "abc")]
        [InlineData("abc123def456", "abc123def456")]
        [InlineData("abc123Def456", "abc123-def456")]
        [InlineData("abc123DEF456", "abc123-def456")]
        [InlineData("ABC123DEF456", "abc123def456")]
        [InlineData("ABC123def456", "abc123def456")]
        [InlineData("Abc123def456", "abc123def456")]
        [InlineData("  abc", "abc")]
        [InlineData("abc  ", "abc")]
        [InlineData("  abc  ", "abc")]
        [InlineData("  abc def  ", "abc-def")]
        public void KebabLowerCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.KebabCaseLower.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "XML-HTTP-REQUEST")]
        [InlineData("camelCase", "CAMEL-CASE")]
        [InlineData("CamelCase", "CAMEL-CASE")]
        [InlineData("snake_case", "SNAKE-CASE")]
        [InlineData("SNAKE_CASE", "SNAKE-CASE")]
        [InlineData("kebab-case", "KEBAB-CASE")]
        [InlineData("KEBAB-CASE", "KEBAB-CASE")]
        [InlineData("double  space", "DOUBLE-SPACE")]
        [InlineData("double__underscore", "DOUBLE-UNDERSCORE")]
        [InlineData("abc", "ABC")]
        [InlineData("abC", "AB-C")]
        [InlineData("aBc", "A-BC")]
        [InlineData("aBC", "A-BC")]
        [InlineData("ABc", "A-BC")]
        [InlineData("ABC", "ABC")]
        [InlineData("abc123def456", "ABC123DEF456")]
        [InlineData("abc123Def456", "ABC123-DEF456")]
        [InlineData("abc123DEF456", "ABC123-DEF456")]
        [InlineData("ABC123DEF456", "ABC123DEF456")]
        [InlineData("ABC123def456", "ABC123DEF456")]
        [InlineData("Abc123def456", "ABC123DEF456")]
        [InlineData("  ABC", "ABC")]
        [InlineData("ABC  ", "ABC")]
        [InlineData("  ABC  ", "ABC")]
        [InlineData("  ABC def  ", "ABC-DEF")]
        public void KebabUpperCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.KebabCaseUpper.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "xmlHttpRequest")]
        [InlineData("camelCase", "camelCase")]
        [InlineData("CamelCase", "camelCase")]
        [InlineData("snake_case", "snakeCase")]
        [InlineData("SNAKE_CASE", "snakeCase")]
        [InlineData("kebab-case", "kebabCase")]
        [InlineData("KEBAB-CASE", "kebabCase")]
        [InlineData("double  space", "doubleSpace")]
        [InlineData("double__underscore", "doubleUnderscore")]
        [InlineData("abc", "abc")]
        [InlineData("abC", "abC")]
        [InlineData("aBc", "aBc")]
        [InlineData("aBC", "aBc")]
        [InlineData("ABc", "aBc")]
        [InlineData("ABC", "abc")]
        [InlineData("abc123def456", "abc123def456")]
        [InlineData("abc123Def456", "abc123Def456")]
        [InlineData("abc123DEF456", "abc123Def456")]
        [InlineData("ABC123DEF456", "abc123def456")]
        [InlineData("ABC123def456", "abc123def456")]
        [InlineData("Abc123def456", "abc123def456")]
        [InlineData("  ABC", "abc")]
        [InlineData("ABC  ", "abc")]
        [InlineData("  ABC  ", "abc")]
        [InlineData("  ABC def  ", "abcDef")]
        public void CamelCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.CamelCase.ConvertName(input));

        [Theory]
        [InlineData("XMLHttpRequest", "XmlHttpRequest")]
        [InlineData("camelCase", "CamelCase")]
        [InlineData("CamelCase", "CamelCase")]
        [InlineData("snake_case", "SnakeCase")]
        [InlineData("SNAKE_CASE", "SnakeCase")]
        [InlineData("kebab-case", "KebabCase")]
        [InlineData("KEBAB-CASE", "KebabCase")]
        [InlineData("double  space", "DoubleSpace")]
        [InlineData("double__underscore", "DoubleUnderscore")]
        [InlineData("abc", "Abc")]
        [InlineData("abC", "AbC")]
        [InlineData("aBc", "ABc")]
        [InlineData("aBC", "ABc")]
        [InlineData("ABc", "ABc")]
        [InlineData("ABC", "Abc")]
        [InlineData("abc123def456", "Abc123def456")]
        [InlineData("abc123Def456", "Abc123Def456")]
        [InlineData("abc123DEF456", "Abc123Def456")]
        [InlineData("ABC123DEF456", "Abc123def456")]
        [InlineData("ABC123def456", "Abc123def456")]
        [InlineData("Abc123def456", "Abc123def456")]
        [InlineData("  ABC", "Abc")]
        [InlineData("ABC  ", "Abc")]
        [InlineData("  ABC  ", "Abc")]
        [InlineData("  ABC def  ", "AbcDef")]
        public void PascalCase(string input, string output) =>
            Assert.Equal(output, JsonNamingPolicies.PascalCase.ConvertName(input));

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "a_haaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "a_towel_it_says_is_about_the_most_massively_useful_thing_an_interstellar_hitchhiker_can_have_partly_it_has_great_practical_value_you_can_wrap_it_around_you_for_warmth_as_you_bound_across_the_cold_moons_of_jaglan_beta_you_can_lie_on_it_on_the_brilliant_marble_sanded_beaches_of_santraginus_v_inhaling_the_heady_sea_vapors_you_can_sleep_under_it_beneath_the_stars_which_shine_so_redly_on_the_desert_world_of_kakrafoon_use_it_to_sail_a_miniraft_down_the_slow_heavy_river_moth_wet_it_for_use_in_hand_to_hand_combat_wrap_it_round_your_head_to_ward_off_noxious_fumes_or_avoid_the_gaze_of_the_ravenous_bugblatter_beast_of_traal_a_mind_bogglingly_stupid_animal_it_assumes_that_if_you_cant_see_it_it_cant_see_you_daft_as_a_brush_but_very_very_ravenous_you_can_wave_your_towel_in_emergencies_as_a_distress_signal_and_of_course_dry_yourself_of_with_it_if_it_still_seems_to_be_clean_enough")]
        public void SnakeLowerCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.SnakeCaseLower);

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "A_HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "A_TOWEL_IT_SAYS_IS_ABOUT_THE_MOST_MASSIVELY_USEFUL_THING_AN_INTERSTELLAR_HITCHHIKER_CAN_HAVE_PARTLY_IT_HAS_GREAT_PRACTICAL_VALUE_YOU_CAN_WRAP_IT_AROUND_YOU_FOR_WARMTH_AS_YOU_BOUND_ACROSS_THE_COLD_MOONS_OF_JAGLAN_BETA_YOU_CAN_LIE_ON_IT_ON_THE_BRILLIANT_MARBLE_SANDED_BEACHES_OF_SANTRAGINUS_V_INHALING_THE_HEADY_SEA_VAPORS_YOU_CAN_SLEEP_UNDER_IT_BENEATH_THE_STARS_WHICH_SHINE_SO_REDLY_ON_THE_DESERT_WORLD_OF_KAKRAFOON_USE_IT_TO_SAIL_A_MINIRAFT_DOWN_THE_SLOW_HEAVY_RIVER_MOTH_WET_IT_FOR_USE_IN_HAND_TO_HAND_COMBAT_WRAP_IT_ROUND_YOUR_HEAD_TO_WARD_OFF_NOXIOUS_FUMES_OR_AVOID_THE_GAZE_OF_THE_RAVENOUS_BUGBLATTER_BEAST_OF_TRAAL_A_MIND_BOGGLINGLY_STUPID_ANIMAL_IT_ASSUMES_THAT_IF_YOU_CANT_SEE_IT_IT_CANT_SEE_YOU_DAFT_AS_A_BRUSH_BUT_VERY_VERY_RAVENOUS_YOU_CAN_WAVE_YOUR_TOWEL_IN_EMERGENCIES_AS_A_DISTRESS_SIGNAL_AND_OF_COURSE_DRY_YOURSELF_OF_WITH_IT_IF_IT_STILL_SEEMS_TO_BE_CLEAN_ENOUGH")]
        public void SnakeUpperCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.SnakeCaseUpper);

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "a-haaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "a-towel-it-says-is-about-the-most-massively-useful-thing-an-interstellar-hitchhiker-can-have-partly-it-has-great-practical-value-you-can-wrap-it-around-you-for-warmth-as-you-bound-across-the-cold-moons-of-jaglan-beta-you-can-lie-on-it-on-the-brilliant-marble-sanded-beaches-of-santraginus-v-inhaling-the-heady-sea-vapors-you-can-sleep-under-it-beneath-the-stars-which-shine-so-redly-on-the-desert-world-of-kakrafoon-use-it-to-sail-a-miniraft-down-the-slow-heavy-river-moth-wet-it-for-use-in-hand-to-hand-combat-wrap-it-round-your-head-to-ward-off-noxious-fumes-or-avoid-the-gaze-of-the-ravenous-bugblatter-beast-of-traal-a-mind-bogglingly-stupid-animal-it-assumes-that-if-you-cant-see-it-it-cant-see-you-daft-as-a-brush-but-very-very-ravenous-you-can-wave-your-towel-in-emergencies-as-a-distress-signal-and-of-course-dry-yourself-of-with-it-if-it-still-seems-to-be-clean-enough")]
        public void KebabLowerCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.KebabCaseLower);

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "A-HAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "A-TOWEL-IT-SAYS-IS-ABOUT-THE-MOST-MASSIVELY-USEFUL-THING-AN-INTERSTELLAR-HITCHHIKER-CAN-HAVE-PARTLY-IT-HAS-GREAT-PRACTICAL-VALUE-YOU-CAN-WRAP-IT-AROUND-YOU-FOR-WARMTH-AS-YOU-BOUND-ACROSS-THE-COLD-MOONS-OF-JAGLAN-BETA-YOU-CAN-LIE-ON-IT-ON-THE-BRILLIANT-MARBLE-SANDED-BEACHES-OF-SANTRAGINUS-V-INHALING-THE-HEADY-SEA-VAPORS-YOU-CAN-SLEEP-UNDER-IT-BENEATH-THE-STARS-WHICH-SHINE-SO-REDLY-ON-THE-DESERT-WORLD-OF-KAKRAFOON-USE-IT-TO-SAIL-A-MINIRAFT-DOWN-THE-SLOW-HEAVY-RIVER-MOTH-WET-IT-FOR-USE-IN-HAND-TO-HAND-COMBAT-WRAP-IT-ROUND-YOUR-HEAD-TO-WARD-OFF-NOXIOUS-FUMES-OR-AVOID-THE-GAZE-OF-THE-RAVENOUS-BUGBLATTER-BEAST-OF-TRAAL-A-MIND-BOGGLINGLY-STUPID-ANIMAL-IT-ASSUMES-THAT-IF-YOU-CANT-SEE-IT-IT-CANT-SEE-YOU-DAFT-AS-A-BRUSH-BUT-VERY-VERY-RAVENOUS-YOU-CAN-WAVE-YOUR-TOWEL-IN-EMERGENCIES-AS-A-DISTRESS-SIGNAL-AND-OF-COURSE-DRY-YOURSELF-OF-WITH-IT-IF-IT-STILL-SEEMS-TO-BE-CLEAN-ENOUGH")]
        public void KebabUpperCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.KebabCaseUpper);

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "aTowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHavePartlyItHasGreatPracticalValueYouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBetaYouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVaporsYouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoonUseItToSailAMiniraftDownTheSlowHeavyRiverMothWetItForUseInHandToHandCombatWrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimalItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenousYouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough")]
        public void CamelCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.CamelCase);

        [Theory]
        [InlineData(
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "aHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            "AHaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa")]
        [InlineData(
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough",
            "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHavePartlyItHasGreatPracticalValueYouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBetaYouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVaporsYouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoonUseItToSailAMiniraftDownTheSlowHeavyRiverMothWetItForUseInHandToHandCombatWrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimalItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenousYouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough")]
        public void PascalCaseLongName(string input, string output) =>
            AssertLongName(input, output, JsonNamingPolicies.PascalCase);

        private void AssertLongName(string input, string output, JsonNamingPolicy policy)
        {
            const int StackAllocLimit = 512;

            Assert.True(input.Length >= StackAllocLimit, $"An input must be longer than {nameof(StackAllocLimit)}.");
            Assert.Equal(output, policy.ConvertName(input));
        }
    }
}
