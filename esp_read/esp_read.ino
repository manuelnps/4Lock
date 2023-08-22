#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "Redmi_Carol";
const char* pwd = "Carol_8226";
String URL = "http://192.168.43.169/teste1_project/readdata.php";

// Rest of your WiFi setup and connection code

void setup() {
  Serial.begin(115200);
  connectWiFi();
}

void loop() {
  if (WiFi.status() != WL_CONNECTED) {
    connectWiFi();
  }

  HTTPClient http;
  http.begin(URL);

  int httpCode = http.GET(); // Use GET request to retrieve data
  if (httpCode > 0) {
        String payload = http.getString();
        Serial.print("Payload: ");
        Serial.println(payload);
      } else {
        Serial.println("Error in HTTP request");
      }
      http.end();
      delay(5000); // Wait for a few seconds before the next request
}

void connectWiFi() {
  WiFi.mode(WIFI_OFF);
  delay(1000);
  //This line hides the viewing of ESP as wifi hotspot
  WiFi.mode(WIFI_STA);
  
  WiFi.begin(ssid, pwd);
  Serial.println("Connecting to WiFi");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
    
  Serial.print("connected to : "); Serial.println(ssid);
  Serial.print("IP address: "); Serial.println(WiFi.localIP());
}