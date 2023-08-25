#include <WiFi.h>
#include <HTTPClient.h>
#include <SPIFFS.h>


const char* ssid = "Redmi_Carol";
const char* pwd = "Carol_8226";
String URL_TAG = "http://192.168.43.169/4lock_project/readdata_TAG.php";
String URL_NMR = "http://192.168.43.169/4lock_project/readdata_NMR.php";
String URL_POS = "http://192.168.43.169/4lock_project/readdata_POS.php";
String URL_NMR_POS = "http://192.168.43.169/4lock_project/readdata_NMR_POS.php";

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
  String payloadNMR_POS = fetchData(URL_NMR_POS);
  String payloadPOS = fetchData(URL_POS);

  if (!payloadTAG.isEmpty() && !payloadNMR.isEmpty() && !payloadNMR_POS.isEmpty() && !payloadPOS.isEmpty()) {
    saveDataToFile("/data_tag.txt", combinePayloads(payloadTAG, payloadNMR));
    saveDataToFile("/data_pos.txt", combinePayloads(payloadPOS, payloadNMR_POS));

    readAndPrintPayload("/data_tag.txt");
    readAndPrintPayload("/data_pos.txt");
    int NMRopen = findNMRValue(1234);
    //Serial.println(NMRopen);
    int POSValue = findPOSValue(NMRopen);
    Serial.println(POSValue);

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

void saveDataToFile(const char *filename, const String &payload) {
  File file = SPIFFS.open(filename, "w");
  if (!file) {
    Serial.println("Failed to open file for writing");
    return;
  }

  file.print(payload);

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

void readAndPrintPayload(const char *filename) {
  File file = SPIFFS.open(filename, "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return;
  }

  Serial.println("Contents of the file " + String(filename) + ":");
  while (file.available()) {
    String line = file.readStringUntil('\n');
    Serial.println(line);
  }

  file.close();
}

int findNMRValue(int targetTAG) {
  File file = SPIFFS.open("/data_tag.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return -1; // Return a special value to indicate an error
  }

  while (file.available()) {
    String line = file.readStringUntil('\n');
    line.trim(); // Remove leading/trailing whitespace
    
    int spaceIndex = line.indexOf(' ');
    if (spaceIndex != -1) {
      int tagValue = line.substring(0, spaceIndex).toInt(); // Get the TAG value
      if (tagValue == targetTAG) {
        int nmrValue = line.substring(spaceIndex + 1).toInt(); // Get the NMR value
        file.close();
        return nmrValue;
      }
    }
  }

  file.close();
  return -1; // Return a special value to indicate that the TAG was not found
}

int findPOSValue(int targetNMR) {
  File file = SPIFFS.open("/data_pos.txt", "r");
  if (!file) {
    Serial.println("Failed to open file for reading");
    return -1; // Return a special value to indicate an error
  }

  while (file.available()) {
    String line = file.readStringUntil('\n');
    line.trim(); // Remove leading/trailing whitespace
    
    int spaceIndex = line.indexOf(' ');
    if (spaceIndex != -1) {
      int nmrValue = line.substring(spaceIndex + 1).toInt(); // Get the NMR value
      if (nmrValue == targetNMR) {
        int posValue = line.substring(0, spaceIndex).toInt(); // Get the POS value
        file.close();
        return posValue;
      }
    }
  }

  file.close();
  return -1; // Return a special value to indicate that the NMR value was not found
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

