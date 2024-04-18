using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Yoh.Text.Json.NamingPolicies.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    public static void Main(string[] args) =>
        BenchmarkRunner.Run<Benchmarks>();

    [Params("XMLHttpRequest", "ATowelItSaysIsAboutTheMostMassivelyUsefulThingAnInterstellarHitchhikerCanHave_PartlyItHasGreatPracticalValue_YouCanWrapItAroundYouForWarmthAsYouBoundAcrossTheColdMoonsOfJaglanBeta_YouCanLieOnItOnTheBrilliantMarbleSandedBeachesOfSantraginusVInhalingTheHeadySeaVapors_YouCanSleepUnderItBeneathTheStarsWhichShineSoRedlyOnTheDesertWorldOfKakrafoon_UseItToSailAMiniraftDownTheSlowHeavyRiverMoth_WetItForUseInHandToHandCombat_WrapItRoundYourHeadToWardOffNoxiousFumesOrAvoidTheGazeOfTheRavenousBugblatterBeastOfTraalAMindBogglinglyStupidAnimal_ItAssumesThatIfYouCantSeeItItCantSeeYouDaftAsABrushButVeryVeryRavenous_YouCanWaveYourTowelInEmergenciesAsADistressSignalAndOfCourseDryYourselfOfWithItIfItStillSeemsToBeCleanEnough")]
    public string Name { get; set; } = string.Empty;

    [Benchmark]
    public string CamelCase() =>
        JsonNamingPolicies.CamelCase.ConvertName(Name);

    [Benchmark]
    public string PascalCase() =>
        JsonNamingPolicies.PascalCase.ConvertName(Name);

    [Benchmark]
    public string SnakeLowerCase() =>
        JsonNamingPolicies.SnakeCaseLower.ConvertName(Name);

    [Benchmark]
    public string SnakeUpperCase() =>
        JsonNamingPolicies.SnakeCaseUpper.ConvertName(Name);

    [Benchmark]
    public string KebabLowerCase() =>
        JsonNamingPolicies.KebabCaseLower.ConvertName(Name);

    [Benchmark]
    public string KebabUpperCase() =>
        JsonNamingPolicies.KebabCaseUpper.ConvertName(Name);
}
