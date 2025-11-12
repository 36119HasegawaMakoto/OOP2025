namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            List<GreetingBase> list = [
                 new GreetingMorning(),
                 new GreetingAfternoon(),
                 new GreetingEvening(),
                ];
            foreach (var obj in list) {
                string msg = obj.GetMessage();
                Console.WriteLine(msg);
            }

        }
    }
    class GreetingMorning : GreetingBase{
        public override string GetMessage() => "おはよう";
    }

    class GreetingAfternoon : GreetingBase {
        public override string GetMessage() => "こんにちは";
    }

    class GreetingEvening : GreetingBase {
        public override string GetMessage() => "こんばんは";
    }



}
