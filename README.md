# spartaTextGame
아이템 클래스 
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

이름 , 효과 , 아이템소개 , 착용여부 , 효과능력치 , 구매가 
6개의 인자를 가짐 
그중 착용여부는 외부에서 조절할수있음 


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
착용여부를 DisplayEquipment()
이쪽에서 판단해서 착용을 하거나 해제할수있음 
착용과 동시에 상태창에 추가 스텟으로 표기됨
