﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace WebBasedChat.Specification
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("WebChat")]
    public partial class WebChatFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "WebChat.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "WebChat", "\tIn order to set up communication\r\n\tAs a wpf application user\r\n\tI want to chat wi" +
                    "th other user", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Start application with Screen 1")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-start-application-from-Screen-1")]
        public virtual void StartApplicationWithScreen1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Start application with Screen 1", null, new string[] {
                        "As-a-User-I-want-to-start-application-from-Screen-1"});
#line 7
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 8
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 9
 testRunner.When("User see application window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 10
 testRunner.Then("Should see Screen 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Store nickname")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-put-my-nickname-on-Screen-1")]
        public virtual void StoreNickname()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Store nickname", null, new string[] {
                        "As-a-User-I-want-to-put-my-nickname-on-Screen-1"});
#line 13
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 14
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 15
 testRunner.When("User see application window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 16
 testRunner.And("User put a nickname \'demo-nick\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Then("Nickname \'demo-nick\' should be stored in application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Proceed from Screen 1 to Screen 2")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-click-proceed-button-on-Screen-1-so-that-I-can-see-Screen-2")]
        public virtual void ProceedFromScreen1ToScreen2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Proceed from Screen 1 to Screen 2", null, new string[] {
                        "As-a-User-I-want-to-click-proceed-button-on-Screen-1-so-that-I-can-see-Screen-2"});
#line 20
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 21
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 22
 testRunner.And("User see application window", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 23
 testRunner.And("User put a nickname \'demo-nick\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 24
 testRunner.When("User click \"Proceed\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("Should see Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("See chat rooms on Screen 2")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-see-existing-chat-rooms-on-Screen-2")]
        public virtual void SeeChatRoomsOnScreen2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("See chat rooms on Screen 2", null, new string[] {
                        "As-a-User-I-want-to-see-existing-chat-rooms-on-Screen-2"});
#line 28
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 29
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 30
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 31
 testRunner.And("User see Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 32
 testRunner.Then("Should see existing chat rooms on Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Create new room")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-click-\"Create-new-room\"-button-so-that-I-can-create-new-chat-" +
            "room")]
        public virtual void CreateNewRoom()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Create new room", null, new string[] {
                        "As-a-User-I-want-to-click-\"Create-new-room\"-button-so-that-I-can-create-new-chat-" +
                            "room"});
#line 35
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 36
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 37
 testRunner.And("User see Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 38
 testRunner.When("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("Chat room is created", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Join new room")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-click-\"Create-new-room\"-button-so-that-I-can-join-selected-ch" +
            "at-room-and-see-Screen-3")]
        public virtual void JoinNewRoom()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Join new room", null, new string[] {
                        "As-a-User-I-want-to-click-\"Create-new-room\"-button-so-that-I-can-join-selected-ch" +
                            "at-room-and-see-Screen-3"});
#line 42
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 43
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 44
 testRunner.And("User see Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 45
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 46
 testRunner.And("User select chat room 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 47
 testRunner.When("User click \"Join\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 48
 testRunner.Then("User join selected chat room", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 49
 testRunner.And("User see Screen 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Send message to roommate")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-enter-some-message-and-press-\"submit\"-button-so-that-I-can-se" +
            "nd-message-to-other-users-in-the-room")]
        public virtual void SendMessageToRoommate()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Send message to roommate", null, new string[] {
                        "As-a-User-I-want-to-enter-some-message-and-press-\"submit\"-button-so-that-I-can-se" +
                            "nd-message-to-other-users-in-the-room"});
#line 52
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 53
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 54
 testRunner.And("User put a nickname \'demo-nick\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 55
 testRunner.And("User click \"Proceed\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 56
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 57
 testRunner.And("User select chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 58
 testRunner.And("User click \"Join\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 59
 testRunner.And("User 1 load rooms", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 60
 testRunner.And("User 2 join chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 61
 testRunner.And("User 3 join chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 62
 testRunner.When("User enter \"some text\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 63
 testRunner.And("User click \"Submit\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 64
 testRunner.Then("\"some text\" was send to user 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 65
 testRunner.And("\"some text\" was send to user 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Get last 30 messages")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-see-last-30-previous-messages-in-current-room-with-authors-an" +
            "d-timestamp")]
        public virtual void GetLast30Messages()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Get last 30 messages", null, new string[] {
                        "As-a-User-I-want-to-see-last-30-previous-messages-in-current-room-with-authors-an" +
                            "d-timestamp"});
#line 68
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 69
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 70
 testRunner.And("User put a nickname \'demo-nick\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 71
 testRunner.And("User click \"Proceed\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 72
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 73
 testRunner.And("User select chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 74
 testRunner.And("User click \"Join\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("User 2 join chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.And("User 3 join chat room 0", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 77
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 78
 testRunner.And("User click \"Create new room\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 79
 testRunner.And("User 4 join chat room 1", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 80
 testRunner.And("User 5 join chat room 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "message"});
            table1.AddRow(new string[] {
                        "Message 1"});
            table1.AddRow(new string[] {
                        "Message 2"});
            table1.AddRow(new string[] {
                        "Message 3"});
            table1.AddRow(new string[] {
                        "Message 4"});
            table1.AddRow(new string[] {
                        "Message 5"});
            table1.AddRow(new string[] {
                        "Message 6"});
            table1.AddRow(new string[] {
                        "Message 7"});
            table1.AddRow(new string[] {
                        "Message 8"});
            table1.AddRow(new string[] {
                        "Message 9"});
            table1.AddRow(new string[] {
                        "Message 10"});
            table1.AddRow(new string[] {
                        "Message 11"});
            table1.AddRow(new string[] {
                        "Message 12"});
            table1.AddRow(new string[] {
                        "Message 13"});
            table1.AddRow(new string[] {
                        "Message 14"});
            table1.AddRow(new string[] {
                        "Message 15"});
#line 81
 testRunner.And("User 2 submit messages", ((string)(null)), table1, "And ");
#line 98
 testRunner.And("User enter \"some text\" message", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 99
 testRunner.And("User click \"Submit\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "message"});
            table2.AddRow(new string[] {
                        "Message 1"});
            table2.AddRow(new string[] {
                        "Message 2"});
            table2.AddRow(new string[] {
                        "Message 3"});
            table2.AddRow(new string[] {
                        "Message 4"});
            table2.AddRow(new string[] {
                        "Message 5"});
            table2.AddRow(new string[] {
                        "Message 6"});
            table2.AddRow(new string[] {
                        "Message 7"});
            table2.AddRow(new string[] {
                        "Message 8"});
            table2.AddRow(new string[] {
                        "Message 9"});
            table2.AddRow(new string[] {
                        "Message 10"});
            table2.AddRow(new string[] {
                        "Message 11"});
            table2.AddRow(new string[] {
                        "Message 12"});
            table2.AddRow(new string[] {
                        "Message 13"});
            table2.AddRow(new string[] {
                        "Message 14"});
            table2.AddRow(new string[] {
                        "Message 15"});
#line 100
 testRunner.And("User 3 submit messages", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "message",
                        "nick",
                        "date"});
#line 118
 testRunner.Then("Following messages was send to user 4", ((string)(null)), table3, "Then ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "message",
                        "nick",
                        "date"});
#line 121
 testRunner.And("Following messages was send to user 5", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "message",
                        "nick",
                        "date"});
            table5.AddRow(new string[] {
                        "Message 2",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 3",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 4",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 5",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 6",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 7",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 8",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 9",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 10",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 11",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 12",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 13",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 14",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 15",
                        "User2",
                        "<date>"});
            table5.AddRow(new string[] {
                        "some text",
                        "demo-nick",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 1",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 2",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 3",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 4",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 5",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 6",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 7",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 8",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 9",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 10",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 11",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 12",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 13",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 14",
                        "User3",
                        "<date>"});
            table5.AddRow(new string[] {
                        "Message 15",
                        "User3",
                        "<date>"});
#line 124
 testRunner.And("Following messages was send to user 1", ((string)(null)), table5, "And ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "message",
                        "nick",
                        "date"});
            table6.AddRow(new string[] {
                        "Message 2",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 3",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 4",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 5",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 6",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 7",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 8",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 9",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 10",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 11",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 12",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 13",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 14",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 15",
                        "User2",
                        "<date>"});
            table6.AddRow(new string[] {
                        "some text",
                        "demo-nick",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 1",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 2",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 3",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 4",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 5",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 6",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 7",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 8",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 9",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 10",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 11",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 12",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 13",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 14",
                        "User3",
                        "<date>"});
            table6.AddRow(new string[] {
                        "Message 15",
                        "User3",
                        "<date>"});
#line 157
 testRunner.And("Following messages was send to user 2", ((string)(null)), table6, "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "message",
                        "nick",
                        "date"});
            table7.AddRow(new string[] {
                        "Message 2",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 3",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 4",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 5",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 6",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 7",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 8",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 9",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 10",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 11",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 12",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 13",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 14",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 15",
                        "User2",
                        "<date>"});
            table7.AddRow(new string[] {
                        "some text",
                        "demo-nick",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 1",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 2",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 3",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 4",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 5",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 6",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 7",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 8",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 9",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 10",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 11",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 12",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 13",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 14",
                        "User3",
                        "<date>"});
            table7.AddRow(new string[] {
                        "Message 15",
                        "User3",
                        "<date>"});
#line 190
 testRunner.And("Following messages was send to user 3", ((string)(null)), table7, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Go back to screen 2")]
        [NUnit.Framework.CategoryAttribute("As-a-User-I-want-to-click-Back-button-so-that-I-can-return-to-the-Screen-2")]
        public virtual void GoBackToScreen2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Go back to screen 2", null, new string[] {
                        "As-a-User-I-want-to-click-Back-button-so-that-I-can-return-to-the-Screen-2"});
#line 226
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 227
 testRunner.Given("User run application", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 228
 testRunner.And("User see Screen 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 229
 testRunner.When("User click \"Back\" button", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 230
 testRunner.Then("Should see Screen 2", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
