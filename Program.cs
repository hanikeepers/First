using System;
using System.Net.Security;
using System.Security.Cryptography;

namespace SolarSystem
{
    public class Calculator 
    {
    delegate float Calculate(float a, float b);
    Calculate onCalculate = (a,b) => 0; // 초기값 제공

    public static void Main()
    {  
        Calculator calculator = new Calculator();
        calculator.onCalculate = calculator.Sum;
        calculator.onCalculate += calculator.Subtract;
        calculator.onCalculate += calculator.Multiply; // 마지막으로 실행한 결과값만 가져옮
     // onCalculate = Sum;  // Sum()은 호출, ()없으면 등록
        calculator.Update(); 
    }   

    public float Sum(float a, float b)
    {;
        Console.WriteLine("Sun "+  (a+b));
        return a+b;
    }

    public float Subtract(float a, float b)
   {
        Console.WriteLine("Subtract " +  (a - b));
        return a-b;
    }

    public float Multiply(float a, float b)
    {
        Console.WriteLine("Multiply " +  (a * b));
        return a*b;  // 리턴값은 Update.result 에 저장
    }

    void Update()
    {
      
       if (onCalculate != null)
        {
            float result = onCalculate(1,10); // 대리자에 의해 실행
            Console.WriteLine(" 결과값 : {0}", result);
         }
        else
        {
          Console.WriteLine("onCalculate에 할당된 델리게이트가 없습니다.");
        }

    }
    }

}