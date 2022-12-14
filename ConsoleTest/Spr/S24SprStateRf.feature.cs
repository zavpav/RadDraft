// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TestConsoleTest.Spr
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Ввод справочника Субъекты")]
    public partial class ВводСправочникаСубъектыFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru-RU"), "Spr", "Ввод справочника Субъекты", "Заполнение справочника Субъекты", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Первичная загрузка данных Субъекты")]
        [NUnit.Framework.CategoryAttribute("регрес")]
        public void ПервичнаяЗагрузкаДанныхСубъекты()
        {
            string[] tagsOfScenario = new string[] {
                    "регрес"};
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Первичная загрузка данных Субъекты", null, tagsOfScenario, argumentsOfScenario, featureTags);
            this.ScenarioInitialize(scenarioInfo);
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
                testRunner.Given("в справочнике \'Субъекты\' количество записей = \'0\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
                TechTalk.SpecFlow.Table table101 = new TechTalk.SpecFlow.Table(new string[] {
                            "Родитель",
                            "Код",
                            "Полное наименование",
                            "Краткое наименование",
                            "Округа:Код -> Округ",
                            "Начало",
                            "Конец"});
                table101.AddRow(new string[] {
                            "",
                            "01",
                            "Республика Башкортостан",
                            "Республика Башкортостан",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "02",
                            "Республика Бурятия",
                            "Республика Бурятия",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "03",
                            "Республика Дагестан",
                            "Республика Дагестан",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "04",
                            "Кабардино-Балкарская Республика",
                            "Каб.-Балкарская Республика",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "05",
                            "Республика Калмыкия",
                            "Республика Калмыкия",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "06",
                            "Республика Карелия",
                            "Республика Карелия",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "07",
                            "Республика Коми",
                            "Республика Коми",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "08",
                            "Республика Марий Эл",
                            "Республика Марий Эл",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "09",
                            "Республика Мордовия",
                            "Республика Мордовия",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "10",
                            "Республика Северная Осетия - Алания",
                            "Республика Сев. Осетия",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "11",
                            "Республика Татарстан",
                            "Республика Татарстан",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "12",
                            "Республика Тыва",
                            "Республика Тыва",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "13",
                            "Удмуртская Республика",
                            "Удмуртская Республика",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "14",
                            "Республика Ингушетия",
                            "Республика Ингушетия",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "15",
                            "Чувашская Республика",
                            "Чувашская Республика",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "16",
                            "Республика Саха (Якутия)",
                            "Республика Саха (Якутия)",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "17",
                            "Алтайский край",
                            "Алтайский край",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "18",
                            "Краснодарский край",
                            "Краснодарский край",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "19",
                            "Красноярский край",
                            "Красноярский край",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "20",
                            "Приморский край",
                            "Приморский край",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "21",
                            "Ставропольский край",
                            "Ставропольский край",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "22",
                            "Хабаровский край",
                            "Хабаровский край",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "23",
                            "Амурская область",
                            "Амурская область",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "24",
                            "Архангельская область и Ненецкий автономный округ",
                            "Архангельская область и Ненецкий автономный округ",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "25",
                            "Астраханская область",
                            "Астраханская область",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "26",
                            "Белгородская область",
                            "Белгородская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "27",
                            "Брянская область",
                            "Брянская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "28",
                            "Владимирская область",
                            "Владимирская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "29",
                            "Волгоградская область",
                            "Волгоградская область",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "30",
                            "Вологодская область",
                            "Вологодская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "31",
                            "Воронежская область",
                            "Воронежская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "32",
                            "Нижегородская область",
                            "Нижегородская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "33",
                            "Ивановская область",
                            "Ивановская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "34",
                            "Иркутская область",
                            "Иркутская область",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "35",
                            "Калининградская область",
                            "Калининградская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "36",
                            "Тверская область",
                            "Тверская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "37",
                            "Калужская область",
                            "Калужская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "38",
                            "Камчатский край",
                            "Камчатский край",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "39",
                            "Кемеровская область",
                            "Кемеровская область",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "40",
                            "Кировская область",
                            "Кировская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "41",
                            "Костромская область",
                            "Костромская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "42",
                            "Самарская область",
                            "Самарская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "43",
                            "Курганская область",
                            "Курганская область",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "44",
                            "Курская область",
                            "Курская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "45",
                            "Ленинградская область",
                            "Ленинградская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "46",
                            "Липецкая область",
                            "Липецкая область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "47",
                            "Магаданская область",
                            "Магаданская область",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "48",
                            "Московская область",
                            "Московская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "49",
                            "Мурманская область",
                            "Мурманская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "50",
                            "Новгородская область",
                            "Новгородская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "51",
                            "Новосибирская область",
                            "Новосибирская область",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "52",
                            "Омская область",
                            "Омская область",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "53",
                            "Оренбургская область",
                            "Оренбургская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "54",
                            "Орловская область",
                            "Орловская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "55",
                            "Пензенская область",
                            "Пензенская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "56",
                            "Пермский край",
                            "Пермский край",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "57",
                            "Псковская область",
                            "Псковская область",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "58",
                            "Ростовская область",
                            "Ростовская область",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "59",
                            "Рязанская область",
                            "Рязанская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "60",
                            "Саратовская область",
                            "Саратовская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "61",
                            "Сахалинская область",
                            "Сахалинская область",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "62",
                            "Свердловская область",
                            "Свердловская область",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "63",
                            "Смоленская область",
                            "Смоленская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "64",
                            "Тамбовская область",
                            "Тамбовская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "65",
                            "Томская область",
                            "Томская область",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "66",
                            "Тульская область",
                            "Тульская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "67",
                            "Тюменская область",
                            "Тюменская область",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "68",
                            "Ульяновская область",
                            "Ульяновская область",
                            "04",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "69",
                            "Челябинская область",
                            "Челябинская область",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "71",
                            "Ярославская область",
                            "Ярославская область",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "72",
                            "г.Санкт-Петербург",
                            "г.Санкт-Петербург",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "73",
                            "г.Москва",
                            "г.Москва",
                            "01",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "74",
                            "г. Севастополь",
                            "г. Севастополь",
                            "09",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "75",
                            "Республика Крым",
                            "Республика Крым",
                            "09",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "76",
                            "Республика Адыгея",
                            "Республика Адыгея",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "77",
                            "Республика Алтай",
                            "Республика Алтай",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "78",
                            "Еврейская автономная область",
                            "Еврейская авт. область",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "79",
                            "Карачаево-Черкесская Республика",
                            "Кар.-Черкесская Республика",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "80",
                            "Республика Хакасия",
                            "Республика Хакасия",
                            "06",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "84",
                            "Архангельская область и Ненецкий автономный округ",
                            "Архангельская область и Ненецкий  АО",
                            "02",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "87",
                            "Ханты-Мансийский автономный округ - Югра",
                            "Ханты-Мансийский АО",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "88",
                            "Чукотский автономный округ",
                            "Чукотский АО",
                            "07",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "90",
                            "Ямало-Ненецкий автономный округ",
                            "Ямало-Ненецкий АО",
                            "05",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "91",
                            "Забайкальский край",
                            "Забайкальский край",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                table101.AddRow(new string[] {
                            "",
                            "94",
                            "Чеченская Республика",
                            "Чеченская Республика",
                            "03",
                            "01.01.1900",
                            "01.01.2100"});
                testRunner.When("вводим в справочник \'Субъекты\' запись:", ((string)(null)), table101, "Когда ");
                testRunner.Then("в справочнике \'Субъекты\' количество записей = \'85\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
