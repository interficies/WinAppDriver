//******************************************************************************
//
// Copyright (c) 2017 Microsoft Corporation. All rights reserved.
//
// This code is licensed under the MIT License (MIT).
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//******************************************************************************

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Windows;

namespace NotepadTest
{
    [TestClass]
    public class ScenarioMenuItem : NotepadSession
    {
        [TestMethod]
        public void MenuItemEditar()
        {
            // Select Edit -> Time/Date to get Time/Date from Notepad
            Assert.AreEqual(string.Empty, editBox.Text);
            WindowsElement editButton = session.FindElementByName("Edición");
            editButton.Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Hora y fecha\")]").Click();
            string timeDateString = editBox.Text;
            Assert.AreNotEqual(string.Empty, timeDateString);

            // Select all text, copy, and paste it twice using MenuItem Edit -> Select All, Copy, and Paste
            editButton.Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Seleccionar todo\")]").Click();
            editButton.Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Copiar\")]").Click();
            editButton.Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Pegar\")]").Click();
            editButton.Click();
            session.FindElementByXPath($"//MenuItem[starts-with(@Name, \"Pegar\")]").Click();

            // Verify that the Time/Date string is duplicated
            Assert.AreEqual(timeDateString + timeDateString, editBox.Text);
        }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Setup(context);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            TearDown();
        }
    }
}
