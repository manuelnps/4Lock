#include <WiFi.h>
#include <HTTPClient.h>
#include <SPIFFS.h>

const char* ssid = "Redmi_Carol";
const char* pwd = "Carol_8226";
String URL_TAG = "http://192.168.43.169/4lock_project/readdata_TAG.php";
String URL_NMR = "http://192.168.43.169/4lock_project/readdata_NMR.php";

// Rest of your WiFi setup and connection code

void setup() {
  Serial.begin(115200);
  connectWiFi();

  if (!SPIFFS.begin(true)) {
    Serial.println("An error occurred while mounting SPIFFS");
    while (1); // Halt the program
  }
}

void loop() {
  if (WiFi.status() != WL_CONNECTED) {
    connectWiFi();
  }

  String payloadTAG = fetchData(URL_TAG);
  String payloadNMR = fetchData(URL_NMR);

  if (!payloadTAG.isEmpty() && !payloadNMR.isEmpty()) {
    saveDataToFile(payloadTAG, payloadNMR);
    readAndPrintPayload();
    deleteAllFiles();
  } else {
    Serial.println("Error in fetching data");
  }

  delay(5000); // Wait for a few seconds before the next request
}

String fetchData(String fetchURL) {
  HTTPClient http;
  http.begin(fetchURL);

  int httpCode = http.GET();
  String payload = "";
  
  if (httpCode > 0) {
    payload = http.getString();
    Serial.println("Fetched payload: " + payload);
  } else {
    Serial.println("Error in HTTP request. HTTP code: " + String(httpCode));
  }

  http.end();
  return payload;
}

void saveDataToFile(const String &payloadTAG, const String &payloadNMR) {
  File file = SPIFFS.open("/data.txt", "w");
  if (!file) {
    Serial.println("Failed to open file for writing");
    return;
  }

  String formattedData = combinePayloads(payloadTAG, payloadNMR);
  file.print(formattedData);

  file.close();
}

String combinePayloads(const String &payloadTAG, const String &payloadNMR) {
  String combinedData = "";
  
  int startPosTAG = 2;  // Skip the first quote and comma
  int startPosNMR = 2;  // Skip the first quote and comma

  while (true) {
    int endPosTAG = payloadTAG.indexOf('"', startPosTAG);
    int endPosNMR = payloadNMR.indexOf('"', startPosNMR);

    if (endPosTAG == -1 || endPosNMR == -1) {
      break;
    }

    String dataTAG = payloadTAG.substring(startPosTAG, endPosTAG);
    String dataNMR = payloadNMR.substring(startPosNMR, endPosNMR);

    combinedData += dataTAG + " " + dataNMR + "\n";

    startPosTAG = endPosTAG + 3;  // Skip the comma and the next quote
    startPosNMR = endPosNMR + 3;  // Skip the comma and the next quote
  }

  return combinedData;
}



String parsePayload(const String &payload) {
  String formattedData = "";

  // Split the payload by commas
  int startPos = 0;
  int endPos;
  while ((endPos = payload.indexOf(',', startPos)) != -1) {
    String data = payload.substring(startPos, endPos);
    formattedData += data + " " + String(2020 + startPos / 2) + "\n";
    startPos = endPos + 1;
  }
  // Write the last data
  String lastData = payload.substring(startPos);
  formattedData += lastData + " " + String(2020 + startPos / 2) + "\n";

  return formattedData;
}

void readAndPrintPayload() {
  File file = SPIFFS.open("/data.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return;
  }

  Serial.println("Contents of the file:");
  while (file.available()) {
    String line = file.readStringUntil('\n');
    Serial.println(line);
  }

  file.close();
}

void deleteAllFiles() {
  File root = SPIFFS.open("/");
  File file = root.openNextFile();
  
  while (file) {
    if (!file.isDirectory()) {
      SPIFFS.remove(file.name());
    }
    file = root.openNextFile();
  }
}


void connectWiFi() {
  WiFi.mode(WIFI_OFF);
  delay(1000);
  // This line hides the viewing of ESP as a WiFi hotspot
  WiFi.mode(WIFI_STA);
  
  WiFi.begin(ssid, pwd);
  Serial.println("Connecting to WiFi");
  
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
    
  Serial.print("Connected to: ");
  Serial.println(ssid);
  Serial.print("IP address: ");
  Serial.println(WiFi.localIP());
}

