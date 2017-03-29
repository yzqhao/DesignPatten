using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatten.BehaviorType
{
    //联合国机构
    abstract class UnitedNations
    {
        /// <summary>
        /// 声明
        /// </summary>
        /// <param name="message">声明信息</param>
        /// <param name="colleague">声明国家</param>
        public abstract void Declare(string message, Country colleague);
    }

    //联合国安全理事会
    class UnitedNationsSecurityCouncil : UnitedNations
    {
        private USA colleague1;
        private Iraq colleague2;

        public USA Colleague1
        {
            set { colleague1 = value; }
        }

        public Iraq Colleague2
        {
            set { colleague2 = value; }
        }

        public override void Declare(string message, Country colleague)
        {
            if (colleague == colleague1)
            {
                colleague2.GetMessage(message);
            }
            else
            {
                colleague1.GetMessage(message);
            }
        }
    }

    //国家
    abstract class Country
    {
        protected UnitedNations mediator;

        public Country(UnitedNations mediator)
        {
            this.mediator = mediator;
        }
    }

    //美国
    class USA : Country
    {
        public USA(UnitedNations mediator)
            : base(mediator)
        {

        }
        //声明
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        //获得消息
        public void GetMessage(string message)
        {
            Console.WriteLine("美国获得对方信息：" + message);
        }
    }

    //伊拉克
    class Iraq : Country
    {
        public Iraq(UnitedNations mediator)
            : base(mediator)
        {
        }

        //声明
        public void Declare(string message)
        {
            mediator.Declare(message, this);
        }
        //获得消息
        public void GetMessage(string message)
        {
            Console.WriteLine("伊拉克获得对方信息：" + message);
        }

    }
}
