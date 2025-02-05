using System.Net.Http;
using System.Xml.Linq;
using System;
using UnityEngine;
using System.Linq;

public class Task2 : MonoBehaviour
{
    private const string url = "https://www.cbr.ru/scripts/XML_daily.asp";

    private void Start() {
        GetCurrency("USD");
        GetCurrency("EUR");
        GetCurrency("CNY");
    }

    private async void GetCurrency(string currencyCode) {
        try {
            using (HttpClient client = new HttpClient()) {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string xmlContent = await response.Content.ReadAsStringAsync();

                XDocument xdoc = XDocument.Parse(xmlContent);
                var currency = xdoc.Descendants("Valute")
                    .FirstOrDefault(x => (string)x.Element("CharCode") == currencyCode);

                if (currency != null) {
                    string name = currency.Element("Name")?.Value;
                    string value = currency.Element("Value")?.Value;
                    print($"Курс {name} ({currencyCode}): {value} руб.");
                }
                else {
                    print($"Валюта {currencyCode} не найдена.");
                }
            }
        }
        catch (Exception ex) {
            print($"Ошибка: {ex.Message}");
        }
    }

}
