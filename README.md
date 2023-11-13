# spartaTextGame

## 만든 부분
* 인벤토리 , 인벤토리-장착관리
* 아이템
  
## 설명
* 장착관리
    * 각 항목에 아이템의 장착여부를 판단해 앞에 장착했다고 보여지게함
    * 장착과 동시에 아이템에 맞는 능력부분과 능력의 수치가 상태창에 반영되게함    

* 아이템
    * 이름, 능력, 아이템설명, 장착여부, 능력수치, 구매가 6개 인자를 가짐
    * 장착여부만 외부에서 수정가능
## 코드
public Item(string name, string options, string description,string equipment, int optionNum,  int gold)
{
    Name = name;
    Options = options;
    Equipment = equipment;
    Description = description;
    OptionNum = optionNum;
    Gold = gold;
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


