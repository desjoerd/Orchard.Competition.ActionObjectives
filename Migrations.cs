using Orchard.Data.Migration;
using System;
using System.Collections.Generic;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using System.Linq;
using System.Web;

namespace DeSjoerd.Competition.ActionObjectives
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("ActionSubmitPartRecord", table => table
                .ContentPartRecord()
                .Column<int>("TeamPartRecord_Id")
                .Column<int>("ObjectivePartRecord_Id")
                .Column<int>("ObjectiveResultPartRecord_Id")
                .Column<string>("Status", c => c.WithDefault("Pending")));

            SchemaBuilder.CreateTable("PhotoSubmitPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("PhotoUrl"));

            SchemaBuilder.CreateTable("VideoSubmitPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("VideoUrl"));

            SchemaBuilder.CreateTable("QuestionObjectivePartRecord", table => table
                .Column<bool>("AutoValidate", column => column.WithDefault(true))
                .ContentPartRecord());

            SchemaBuilder.CreateTable("QuestionAnswerRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<int>("QuestionObjectivePartRecord_Id")
                .Column<string>("Answer"));

            SchemaBuilder.CreateTable("QuestionSubmitPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("Answer"));

            ContentDefinitionManager.AlterTypeDefinition("PhotoObjective", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder => partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Game-Title and Objective-Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'Games/Lego/Ringen-Verzamelen'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("ObjectivePart")
                .WithPart("ActionObjectivePart")
                .Draftable());

            ContentDefinitionManager.AlterTypeDefinition("PhotoSubmit", builder => builder
                .WithPart("CommonPart")
                .WithPart("ActionSubmitPart")
                .WithPart("PhotoSubmitPart"));

            ContentDefinitionManager.AlterTypeDefinition("VideoObjective", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder => partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Game-Title and Objective-Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'Games/Lego/Ringen-Verzamelen'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("ObjectivePart")
                .WithPart("ActionObjectivePart")
                .Draftable());

            ContentDefinitionManager.AlterTypeDefinition("VideoSubmit", builder => builder
                .WithPart("CommonPart")
                .WithPart("ActionSubmitPart")
                .WithPart("VideoSubmitPart"));

            ContentDefinitionManager.AlterTypeDefinition("QuestionObjective", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder => partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Game-Title and Objective-Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'Games/Lego/Ringen-Verzamelen'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("ObjectivePart")
                .WithPart("ActionObjectivePart")
                .WithPart("QuestionObjectivePart")
                .Draftable());

            ContentDefinitionManager.AlterTypeDefinition("QuestionSubmit", builder => builder
                .WithPart("CommonPart")
                .WithPart("ActionSubmitPart")
                .WithPart("QuestionSubmitPart"));

            return 5;
        }

        public int UpdateFrom1()
        {
            ContentDefinitionManager.AlterTypeDefinition("VideoObjective", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder => partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Game-Title and Objective-Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'Games/Lego/Ringen-Verzamelen'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("ObjectivePart")
                .WithPart("ActionObjectivePart")
                .Draftable());

            return 2;
        }

        public int UpdateFrom2()
        {
            ContentDefinitionManager.AlterTypeDefinition("VideoSubmit", builder => builder
                .WithPart("CommonPart")
                .WithPart("ActionSubmitPart")
                .RemovePart("PhotoSubmitPart")
                .WithPart("VideoSubmitPart"));

            return 3;
        }

        public int UpdateFrom3()
        {
            SchemaBuilder.CreateTable("QuestionObjectivePartRecord", table => table
                .ContentPartRecord());

            SchemaBuilder.CreateTable("QuestionAnswerRecord", table => table
                .Column<int>("Id", column => column.PrimaryKey().Identity())
                .Column<int>("QuestionObjectivePartRecord_Id")
                .Column<string>("Answer"));

            SchemaBuilder.CreateTable("QuestionSubmitPartRecord", table => table
                .ContentPartRecord()
                .Column<string>("Answer"));

            ContentDefinitionManager.AlterTypeDefinition("QuestionObjective", builder => builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder => partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name:'Game-Title and Objective-Title', Pattern: '{Content.Container.Path}/{Content.Slug}', Description: 'Games/Lego/Ringen-Verzamelen'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0"))
                .WithPart("ObjectivePart")
                .WithPart("ActionObjectivePart")
                .WithPart("QuestionObjectivePart")
                .Draftable());

            ContentDefinitionManager.AlterTypeDefinition("QuestionSubmit", builder => builder
                .WithPart("CommonPart")
                .WithPart("ActionSubmitPart")
                .WithPart("QuestionSubmitPart"));

            return 4;
        }

        public int UpdateFrom4()
        {
            SchemaBuilder.AlterTable("QuestionObjectivePartRecord", table => table
                .AddColumn<bool>("AutoValidate", column => column.WithDefault(true)));

            return 5;
        }

        public int UpdateFrom5()
        {
            SchemaBuilder.AlterTable("QuestionObjectivePartRecord", table => table
                .AddColumn<string>("Hint"));

            SchemaBuilder.AlterTable("QuestionObjectivePartRecord", table => table
                .AddColumn<int>("HintPrice"));

            return 6;
        }

        public int UpdateFrom6()
        {
            SchemaBuilder.CreateTable("TeamUsedHintRecord", table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<int>("QuestionObjectivePartRecord_Id")
                .Column<int>("TeamPartRecord_Id"));

            return 8;
        }

        public int UpdateFrom7()
        {
            // bugfix
            SchemaBuilder.DropTable("TeamUsedHintRecord");

            SchemaBuilder.CreateTable("TeamUsedHintRecord", table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<int>("QuestionObjectivePartRecord_Id")
                .Column<int>("TeamPartRecord_Id"));

            return 8;
        }

        public int UpdateFrom8()
        {
            SchemaBuilder.AlterTable("QuestionObjectivePartRecord", table => table
                .AddColumn<bool>("IsMultipleChoice"));

            SchemaBuilder.CreateTable("QuestionChoiceRecord", table => table
                .Column<int>("Id", c => c.PrimaryKey().Identity())
                .Column<int>("QuestionObjectivePartRecord_Id")
                .Column<string>("Choice"));

            return 9;
        }

        public int UpdateFrom9()
        {
            SchemaBuilder.AlterTable("QuestionObjectivePartRecord", table => table
                .AddColumn<int>("MaxTries"));

            return 10;
        }
    }
}