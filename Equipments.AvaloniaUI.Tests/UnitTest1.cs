using System;
using Xunit;

namespace Equipments.AvaloniaUI.Tests
{
    public class UserAuthenticationTests
    {
        [Fact]
        public void TestALogin()
        {
            //������� ������� � �������
            string[] login = new string[] { "admin", "fail_user" };
            string[] password = new string[] { "adminpass", "fail_password" };
            bool[] expectedResults = new bool[] { true, false }; //��������� �������� ��� �����������

            for (int i = 0; i < login.Length; i++) //�������� ������� � �������
            {
                bool isLogin = Login(login[i], password[i]);
                Assert.Equal(expectedResults[i], isLogin);
            }
        }
        private bool Login(string login, string password)
        {
            //�������� �����������
            if (login == "admin" && password == "adminpass")
            {
                return true;
            }

            return false;
        }
    }
}
