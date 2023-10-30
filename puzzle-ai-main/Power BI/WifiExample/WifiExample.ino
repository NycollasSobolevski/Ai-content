#include "DHT.h"
#include <WiFi.h>
#include <FirebaseESP32.h>

#define WIFI_SSID "Vivo-Internet-BF17"
#define WIFI_PASSWORD "78814222"

#define FIREBASE_HOST "https://dhtexample-default-rtdb.firebaseio.com"
#define FIREBASE_AUTH "hYzIL4HcjExUEUpLdat3gPzPeR0Cs5nBU0t43v5n"

#define DHTPin 33
#define DHTTYPE DHT11


FirebaseData firebaseData;
FirebaseJson json;

DHT dht(DHTPin, DHTTYPE);

float temp;
float hum;
void setup()
{
  Firebase.begin(FIREBASE_HOST, FIREBASE_AUTH);
  Firebase.reconnectWiFi(true);
  Firebase.setReadTimeout(firebaseData, 1000 * 60);
  Firebase.setwriteSizeLimit(firebaseData, "tiny");

  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.begin(9600);

  while (WiFi.status() != WL_CONNECTED)
  {
    Serial.print(".");
  }

  Serial.print("\nConnected with IP: ");
  Serial.println(WiFi.localIP());
}

void loop() {
  temp = dht.readTemperature();
  Serial.print("Temperatura: ");
  Serial.println(temp);
  json.set("/Temperatura", temp);

  hum = dht.readHumidity();
  Serial.print("Humidade: ");
  Serial.println(hum);
  json.set("/Umidade", hum);
  Firebase.updateNode(firebaseData, "/Falas/Sensor", json);
  delay(2000);
}
