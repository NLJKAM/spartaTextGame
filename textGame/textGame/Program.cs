namespace textGame
{
    internal class Program
    {
        private static Character player;
        private static Item ironArmor;
        private static Item oldSword;
        private static int itemATK = 0;
        private static int itemDEF = 0;

        static void Main(string[] args)
        {
            GameDataSetting();
            DisplayGameIntro();
        }

        static void GameDataSetting()
        {
            // 캐릭터 정보 세팅
            player = new Character("오전5시2분", "전사", 1, 10, 5, 100, 1500);
            // 아이템 정보 세팅
            ironArmor = new Item("무쇠갑옷","방어력","무쇠로 만들어져 튼튼한 갑옷입니다.","",5,0);
           oldSword = new Item("낡은 검","공격력","쉽게 볼 수 있는 낡은 검 입니다.","",2,0);
        }

        static void DisplayGameIntro()
        {
            Console.Clear();

            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 전전으로 들어가기 전 활동을 할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine("1. 상태보기");
            Console.WriteLine("2. 인벤토리");
            Console.WriteLine();
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(1, 2);
            switch (input)
            {
                case 1:
                    DisplayMyInfo();
                    break;

                case 2:
                    // 작업해보기
                    DisplayInventory();
                    break;
            }
        }

        static void DisplayMyInfo()
        {
            Console.Clear();
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시합니다.");
            Console.WriteLine();
            Console.WriteLine($"Lv.{player.Level}");
            Console.WriteLine($"{player.Name}({player.Job})");
            if (itemATK != 0)
            {
                Console.WriteLine($"공격력 :{player.Atk} (+{itemATK})");
            }
            else
            {
                Console.WriteLine($"공격력 :{player.Atk}");
            }
            if (itemDEF != 0)
            {
                Console.WriteLine($"방어력 : {player.Def} (+{itemDEF})");
            }
            else
            {
                Console.WriteLine($"방어력 : {player.Def}");
            }
            Console.WriteLine($"체력 : {player.Hp}");
            Console.WriteLine($"Gold : {player.Gold} G");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");

            int input = CheckValidInput(0, 0);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;
            }
        }

        static void DisplayInventory()
        {
            Console.Clear();
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"[아이템 목록]");
            Console.WriteLine($"- {ironArmor.Equipment}{ironArmor.Name}   | {ironArmor.Options} +{ironArmor.OptionNum} | {ironArmor.Description}");
            Console.WriteLine($"- {oldSword.Equipment}{oldSword.Name}   | {oldSword.Options} +{oldSword.OptionNum} | {oldSword.Description}");
            Console.WriteLine();
            Console.WriteLine("1. 장착 관리");
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 1);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;

                case 1:
                    DisplayEquipment();
                    break;
            }
        }
        static void DisplayEquipment()
        {
            Console.Clear();
            Console.WriteLine("인벤토리 - 장착 관리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
            Console.WriteLine();
            Console.WriteLine($"[아이템 목록]");
            Console.WriteLine($"- 1 {ironArmor.Equipment}{ironArmor.Name}   | {ironArmor.Options} +{ironArmor.OptionNum} | {ironArmor.Description}");
            Console.WriteLine($"- 2 {oldSword.Equipment}{oldSword.Name}   | {oldSword.Options} +{oldSword.OptionNum} | {oldSword.Description}");
            Console.WriteLine();
            Console.WriteLine("0. 나가기");
            Console.WriteLine("원하시는 행동을 입력해주세요.");

            int input = CheckValidInput(0, 2);
            switch (input)
            {
                case 0:
                    DisplayGameIntro();
                    break;

                case 1:
                    if(ironArmor.Equipment == "")
                    {
                        ironArmor.Equipment = "[E]";
                        itemDEF += ironArmor.OptionNum;
                    }
                    else if (ironArmor.Equipment == "[E]")
                    {
                        ironArmor.Equipment = "";
                        itemDEF -= ironArmor.OptionNum;
                    }
                    DisplayEquipment();
                    break;

                case 2:
                    if (oldSword.Equipment == "")
                    {
                        oldSword.Equipment = "[E]";
                        itemATK += oldSword.OptionNum;
                    }
                    else if (oldSword.Equipment == "[E]")
                    {
                        oldSword.Equipment = "";
                        itemATK -= oldSword.OptionNum; 
                    }
                    DisplayEquipment();
                    break;
            }
        }
        static int CheckValidInput(int min, int max)
        {
            while (true)
            {
                string input = Console.ReadLine();

                bool parseSuccess = int.TryParse(input, out var ret);
                if (parseSuccess)
                {
                    if (ret >= min && ret <= max)
                        return ret;
                }

                Console.WriteLine("잘못된 입력입니다.");
            }
        }
    }


    public class Character
    {
        public string Name { get; }
        public string Job { get; }
        public int Level { get; }
        public int Atk { get; }
        public int Def { get; }
        public int Hp { get; }
        public int Gold { get; }

        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Atk = atk;
            Def = def;
            Hp = hp;
            Gold = gold;
        }
    }
    public class Item
    {
        public string Name { get; }
        public string Options { get; }
        public string Description { get; }
        public string Equipment { get; set; }
        public int OptionNum { get; }
        public int Gold { get; }

        public Item(string name, string options, string description,string equipment, int optionNum,  int gold)
        {
            Name = name;
            Options = options;
            Equipment = equipment;
            Description = description;
            OptionNum = optionNum;
            Gold = gold;
        }
    }
}