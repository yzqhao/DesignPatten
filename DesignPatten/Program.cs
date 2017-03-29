using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DesignPatten.StructureType;
using DesignPatten.BehaviorType;

namespace DesignPatten
{
    class Program
    {
        static void Main(string[] args)
        {
            StructureTypeDesign.testFacade();
        }
    }

    class StructureTypeDesign
    {
        //适配
        public static void testAdaptee()
        {
            Player b = new Forwards("巴蒂尔");
            b.Attack();

            Player m = new Guards("麦克格雷迪");
            m.Attack();

            //Player ym = new Center("姚明");
            Player ym = new Translator("姚明");
            ym.Attack();
            ym.Defense();

            Console.Read();
        }

        //桥接
        public static void testBridge()
        {
            Abstraction ab = new RefinedAbstraction();

            ab.SetImplementor(new ConcreteImplementorA());
            ab.Operation();

            ab.SetImplementor(new ConcreteImplementorB());
            ab.Operation();

            Console.Read();
        }

        //组合
        public static void testComposite()
        {
            ConcreteCompany root = new ConcreteCompany("北京总公司");
            root.Add(new HRDepartment("总公司人力资源部"));
            root.Add(new FinanceDepartment("总公司财务部"));

            ConcreteCompany comp = new ConcreteCompany("上海华东分公司");
            comp.Add(new HRDepartment("华东分公司人力资源部"));
            comp.Add(new FinanceDepartment("华东分公司财务部"));
            root.Add(comp);

            ConcreteCompany comp1 = new ConcreteCompany("南京办事处");
            comp1.Add(new HRDepartment("南京办事处人力资源部"));
            comp1.Add(new FinanceDepartment("南京办事处财务部"));
            comp.Add(comp1);

            ConcreteCompany comp2 = new ConcreteCompany("杭州办事处");
            comp2.Add(new HRDepartment("杭州办事处人力资源部"));
            comp2.Add(new FinanceDepartment("杭州办事处财务部"));
            comp.Add(comp2);


            Console.WriteLine("\n结构图：");

            root.Display(1);

            Console.WriteLine("\n职责：");

            root.LineOfDuty();


            Console.Read();
        }

        //装饰
        public static void testDecorator()
        {
            ConcreteComponent c = new ConcreteComponent();
            ConcreteDecoratorA d1 = new ConcreteDecoratorA();
            ConcreteDecoratorB d2 = new ConcreteDecoratorB();

            d1.SetComponent(c);
            d2.SetComponent(d1);

            d2.Operation();

            Console.Read();
        }

        //外观
        public static void testFacade()
        {
            Fund jijin = new Fund();

            jijin.BuyFund();
            jijin.SellFund();

            Console.Read();
        }

        //享元
        public static void testFlyweight()
        {
            WebSiteFactory f = new WebSiteFactory();

            WebSite fx = f.GetWebSiteCategory("产品展示");
            fx.Use(new User("小菜"));

            WebSite fy = f.GetWebSiteCategory("产品展示");
            fy.Use(new User("大鸟"));

            WebSite fz = f.GetWebSiteCategory("产品展示");
            fz.Use(new User("娇娇"));

            WebSite fl = f.GetWebSiteCategory("博客");
            fl.Use(new User("老顽童"));

            WebSite fm = f.GetWebSiteCategory("博客");
            fm.Use(new User("桃谷六仙"));

            WebSite fn = f.GetWebSiteCategory("博客");
            fn.Use(new User("南海鳄神"));

            Console.WriteLine("得到网站分类总数为 {0}", f.GetWebSiteCount());

            //string titleA = "大话设计模式";
            //string titleB = "大话设计模式";

            //Console.WriteLine(Object.ReferenceEquals(titleA, titleB));


            Console.Read();
        }

        //代理
        public static void testProxy()
        {
            SchoolGirl jiaojiao = new SchoolGirl();
            jiaojiao.Name = "李娇娇";

            Proxy daili = new Proxy(jiaojiao);

            daili.GiveDolls();
            daili.GiveFlowers();
            daili.GiveChocolate();


            Console.Read();
        }
    }

    class CreateTypeDesign
    {
        //抽象工厂
        public static void testAbstractFactory()
        {
            AbstractFactory factory1 = new ConcreteFactory1();
            Client c1 = new Client(factory1);
            c1.Run();

            AbstractFactory factory2 = new ConcreteFactory2();
            Client c2 = new Client(factory2);
            c2.Run();

            Console.Read();
        }

        //建造者
        public static void testBuild()
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

            director.Construct(b1);
            Product p1 = b1.GetResult();
            p1.Show();

            director.Construct(b2);
            Product p2 = b2.GetResult();
            p2.Show();

            Console.Read();
        }

        //工程方法
        public static void testFactoryMethod()
        {
            IFactory operFactory = new MulFactory();
            Operation oper = operFactory.CreateOperation();
            oper.NumberA = 1;
            oper.NumberB = 2;
            double result = oper.GetResult();

            Console.WriteLine(result);

            Console.Read();
        }

        //单例模式
        public static void testSingleton()
        {
            Singleton s1 = Singleton.GetInstance();
            Singleton s2 = Singleton.GetInstance();

            if (s1 == s2)
            {
                Console.WriteLine("Objects are the same instance");
            }

            Console.Read();
        }

        //原型模式
        public static void testPrototype()
        {
            Resume a = new Resume("大鸟");
            a.SetPersonalInfo("男", "29");
            a.SetWorkExperience("1998-2000", "XX公司");

            Resume b = (Resume)a.Clone();
            b.SetWorkExperience("1998-2006", "YY企业");

            Resume c = (Resume)a.Clone();
            c.SetWorkExperience("1998-2003", "ZZ企业");

            a.Display();
            b.Display();
            c.Display();

            // Wait for user 
            Console.Read();
        }
    }

    class BehaviorTypeDesign
    {
        //职责链
        public static void testChain()
        {
            CommonManager jinli = new CommonManager("金利");
            Majordomo zongjian = new Majordomo("宗剑");
            GeneralManager zhongjingli = new GeneralManager("钟精励");
            jinli.SetSuperior(zongjian);
            zongjian.SetSuperior(zhongjingli);

            Request request = new Request();
            request.RequestType = "请假";
            request.RequestContent = "小菜请假";
            request.Number = 1;
            jinli.RequestApplications(request);

            Request request2 = new Request();
            request2.RequestType = "请假";
            request2.RequestContent = "小菜请假";
            request2.Number = 4;
            jinli.RequestApplications(request2);

            Request request3 = new Request();
            request3.RequestType = "加薪";
            request3.RequestContent = "小菜请求加薪";
            request3.Number = 500;
            jinli.RequestApplications(request3);

            Request request4 = new Request();
            request4.RequestType = "加薪";
            request4.RequestContent = "小菜请求加薪";
            request4.Number = 1000;
            jinli.RequestApplications(request4);

            Console.Read();
        }

        //命令
        public static void testCommand()
        {
            //开店前的准备
            Barbecuer boy = new Barbecuer();
            Command bakeMuttonCommand1 = new BakeMuttonCommand(boy);
            Command bakeMuttonCommand2 = new BakeMuttonCommand(boy);
            Command bakeChickenWingCommand1 = new BakeChickenWingCommand(boy);
            Waiter girl = new Waiter();

            //开门营业 顾客点菜
            girl.SetOrder(bakeMuttonCommand1);
            girl.SetOrder(bakeMuttonCommand2);
            girl.SetOrder(bakeChickenWingCommand1);

            //点菜完闭，通知厨房
            girl.Notify();

            Console.Read();
        }

        //解释器
        public static void testInterpreter()
        {
            PlayContext context = new PlayContext();
            //音乐-上海滩
            Console.WriteLine("上海滩：");
            //context.演奏文本 = "T 500 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 D 0.5 E 0.5 G 3 D 0.5 E 0.5 O 1 A 3 A 0.5 O 2 C 0.5 D 1.5 E 0.5 D 0.5 O 1 B 0.5 A 0.5 O 2 C 0.5 O 1 G 3 P 0.5 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 D 0.5 E 0.5 G 3 D 0.5 E 0.5 O 1 A 3 A 0.5 O 2 C 0.5 D 1.5 E 0.5 D 0.5 O 1 B 0.5 A 0.5 G 0.5 O 2 C 3 P 0.5 O 3 C 0.5 C 0.5 O 2 A 0.5 O 3 C 2 P 0.5 O 2 A 0.5 O 3 C 0.5 O 2 A 0.5 G 2.5 G 0.5 E 0.5 A 1.5 G 0.5 C 1 D 0.25 C 0.25 D 0.5 E 2.5 E 0.5 E 0.5 D 0.5 E 2.5 O 3 C 0.5 C 0.5 O 2 B 0.5 A 3 E 0.5 E 0.5 D 1.5 E 0.5 O 3 C 0.5 O 2 B 0.5 A 0.5 E 0.5 G 2 P 0.5 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 D 0.5 E 0.5 G 3 D 0.5 E 0.5 O 1 A 3 A 0.5 O 2 C 0.5 D 1.5 E 0.5 D 0.5 O 1 B 0.5 A 0.5 G 0.5 O 2 C 3 ";
            context.PlayText = "T 500 O 2 E 0.5 G 0.5 A 3 E 0.5 G 0.5 D 3 E 0.5 G 0.5 A 0.5 O 3 C 1 O 2 A 0.5 G 1 C 0.5 E 0.5 D 3 ";
            //音乐-隐形的翅膀
            //Console.WriteLine("隐形的翅膀："); 
            //context.演奏文本 = "T 1000 O 1 G 0.5 O 2 C 0.5 E 1.5 G 0.5 E 1 D 0.5 C 0.5 C 0.5 C 0.5 C 0.5 O 1 A 0.25 G 0.25 G 1 G 0.5 O 2 C 0.5 E 1.5 G 0.5 G 0.5 G 0.5 A 0.5 G 0.5 G 0.5 D 0.25 E 0.25 D 0.5 C 0.25 D 0.25 D 1 A 0.5 G 0.5 E 1.5 G 0.5 G 0.5 G 0.5 A 0.5 G 0.5 E 0.5 D 0.5 C 0.5 C 0.25 D 0.25 O 1 A 1 G 0.5 A 0.5 O 2 C 1.5 D 0.25 E 0.25 D 1 E 0.5 C 0.5 C 3 O 1 G 0.5 O 2 C 0.5 E 1.5 G 0.5 E 1 D 0.5 C 0.5 C 0.5 C 0.5 C 0.5 O 1 A 0.25 G 0.25 G 1 G 0.5 O 2 C 0.5 E 1.5 G 0.5 G 0.5 G 0.5 A 0.5 G 0.5 G 0.5 D 0.25 E 0.25 D 0.5 C 0.25 D 0.25 D 1 A 0.5 G 0.5 E 1.5 G 0.5 G 0.5 G 0.5 A 0.5 G 0.5 E 0.5 D 0.5 C 0.5 C 0.25 D 0.25 O 1 A 1 G 0.5 A 0.5 O 2 C 1.5 D 0.25 E 0.25 D 1 E 0.5 C 0.5 C 3 E 0.5 G 0.5 O 3 C 1.5 O 2 B 0.25 O 3 C 0.25 O 2 B 1 A 0.5 G 0.5 A 0.5 O 3 C 0.5 O 2 E 0.5 D 0.5 C 1 C 0.5 C 0.5 C 0.5 O 3 C 1 O 2 G 0.25 A 0.25 G 0.5 D 0.25 E 0.25 D 0.5 C 0.25 D 0.25 D 3 E 0.5 G 0.5 O 3 C 1.5 O 2 B 0.25 O 3 C 0.25 O 2 B 1 A 0.5 G 0.5 A 0.5 O 3 C 0.5 O 2 E 0.5 D 0.5 C 1 C 0.5 C 0.5 C 0.5 O 3 C 1 O 2 G 0.25 A 0.25 G 0.5 D 0.25 E 0.25 D 0.5 C 0.5 C 3 ";
            Expression expression = null;
            try
            {
                while (context.PlayText.Length > 0)
                {
                    string str = context.PlayText.Substring(0, 1);
                    switch (str)
                    {
                        case "O":
                            expression = new Scale();
                            break;
                        case "T":
                            expression = new Speed();
                            break;
                        case "C":
                        case "D":
                        case "E":
                        case "F":
                        case "G":
                        case "A":
                        case "B":
                        case "P":
                            expression = new Note();
                            break;

                    }
                    expression.Interpret(context);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }

        //迭代器
        public static void testIterator()
        {
            ConcreteAggregate a = new ConcreteAggregate();

            a[0] = "大鸟";
            a[1] = "小菜";
            a[2] = "行李";
            a[3] = "老外";
            a[4] = "公交内部员工";
            a[5] = "小偷";

            Iterator i = new ConcreteIterator(a);
            //Iterator i = new ConcreteIteratorDesc(a);
            object item = i.First();
            while (!i.IsDone())
            {
                Console.WriteLine("{0} 请买车票!", i.CurrentItem());
                i.Next();
            }

            Console.Read();        
        }

        //中介者
        public static void testMediator()
        {
            UnitedNationsSecurityCouncil UNSC = new UnitedNationsSecurityCouncil();

            USA c1 = new USA(UNSC);
            Iraq c2 = new Iraq(UNSC);

            UNSC.Colleague1 = c1;
            UNSC.Colleague2 = c2;

            c1.Declare("不准研制核武器，否则要发动战争！");
            c2.Declare("我们没有核武器，也不怕侵略。");

            Console.Read();
        }

        //备忘录
        public static void testMemento()
        {
            //大战Boss前
            GameRole lixiaoyao = new GameRole();
            lixiaoyao.GetInitState();
            lixiaoyao.StateDisplay();

            //保存进度
            RoleStateCaretaker stateAdmin = new RoleStateCaretaker();
            stateAdmin.Memento = lixiaoyao.SaveState();

            //大战Boss时，损耗严重
            lixiaoyao.Fight();
            lixiaoyao.StateDisplay();

            //恢复之前状态
            lixiaoyao.RecoveryState(stateAdmin.Memento);

            lixiaoyao.StateDisplay();


            Console.Read();
        }

        //观察者
        public static void testObserver()
        {
            //老板胡汉三
            Boss huhansan = new Boss();

            //看股票的同事
            StockObserver tongshi1 = new StockObserver("魏关姹", huhansan);
            //看NBA的同事
            NBAObserver tongshi2 = new NBAObserver("易管查", huhansan);

            huhansan.Update += new DesignPatten.BehaviorType.EventHandler(tongshi1.CloseStockMarket);
            huhansan.Update += new DesignPatten.BehaviorType.EventHandler(tongshi2.CloseNBADirectSeeding);

            //老板回来
            huhansan.SubjectState = "我胡汉三回来了！";
            //发出通知
            huhansan.Notify();

            Console.Read();
        }

        //状态
        public static void testState()
        {
            //紧急项目
            Work emergencyProjects = new Work();
            emergencyProjects.Hour = 9;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 10;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 12;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 13;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 14;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 17;

            //emergencyProjects.WorkFinished = true;
            emergencyProjects.TaskFinished = false;

            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 19;
            emergencyProjects.WriteProgram();
            emergencyProjects.Hour = 22;
            emergencyProjects.WriteProgram();

            Console.Read();
        }

        //策略
        public static void testStrategy()
        {
            SortedList studentRecords = new SortedList();
            studentRecords.Add("Samual");
            studentRecords.Add("Jimmy");
            studentRecords.Add("Sandra");
            studentRecords.Add("Anna");
            studentRecords.Add("Vivek");

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();
            studentRecords.Display();

            Console.Read();
        }

        //工厂方法
        public static void testTemplateMethod()
        {
            Console.WriteLine("学生甲抄的试卷：");
            TestPaper studentA = new TestPaperA();
            studentA.TestQuestion1();
            studentA.TestQuestion2();
            studentA.TestQuestion3();

            Console.WriteLine("学生乙抄的试卷：");
            TestPaper studentB = new TestPaperB();
            studentB.TestQuestion1();
            studentB.TestQuestion2();
            studentB.TestQuestion3();

            Console.Read();
        }

        //访问者
        public static void testVisitor()
        {
            ObjectStructure o = new ObjectStructure();
            o.Attach(new Man());
            o.Attach(new Woman());

            Success v1 = new Success();
            o.Display(v1);

            Failing v2 = new Failing();
            o.Display(v2);

            Amativeness v3 = new Amativeness();
            o.Display(v3);

            Marriage v4 = new Marriage();
            o.Display(v4);

            Console.Read();
        }
    }
}
