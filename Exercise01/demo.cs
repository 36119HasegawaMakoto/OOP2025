//これを10.1で使用する
namespace Exercise01 {
    public class EmptyLogic {
        public class Inner {
            public void DoNothing() {
                int number = 42;
                string message = "This is a meaningless string.";
                Console.WriteLine($"{message} : {number}");
            }
        }

        public void Start() {
            Inner inner = new Inner();
            inner.DoNothing();
        }
    }

    public class AnotherEmpty {
        public void Execute() {
            Console.WriteLine("Executing nothing.");
        }
    }
}

