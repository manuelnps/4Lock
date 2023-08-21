#include <esp_now.h>
#include <WiFi.h>

uint8_t broadcastAddress[] = {0xa8, 0x42, 0xe3, 0xcd, 0xfa, 0x28};
// variáveis a enviar
float xi;
float yi;

// variáveis a armazenar
float xii;
float yii;

String success; // isto é estúpido

typedef struct struct_message {
  float x;
  float y;
} struct_message;

struct_message Enviado;
struct_message Recebido;





esp_now_peer_info_t peerInfo;

// Callback when data is sent
void OnDataSent(const uint8_t *mac_addr, esp_now_send_status_t status) {
  Serial.print("\r\nLast Packet Send Status:\t");
  Serial.println(status == ESP_NOW_SEND_SUCCESS ? "Delivery Success" : "Delivery Fail");
  if (status ==0){
    success = "Delivery Success :)";
  }
  else{
    success = "Delivery Fail :(";
  }
}

// Callback when data is received
void OnDataRecv(const uint8_t * mac, const uint8_t *incomingData, int len) {
  memcpy(&Recebido, incomingData, sizeof(Recebido));
  Serial.print("Bytes received: ");
  Serial.println(len);
  xii = Recebido.x;
  yii = Recebido.y;
}
 
void setup() {
  // Init Serial Monitor
  Serial.begin(115200);

 
  // Set device as a Wi-Fi Station
  WiFi.mode(WIFI_STA);

  // Init ESP-NOW
  if (esp_now_init() != ESP_OK) {
    Serial.println("Error initializing ESP-NOW");
    return;
  }

  // Once ESPNow is successfully Init, we will register for Send CB to
  // get the status of Trasnmitted packet
  esp_now_register_send_cb(OnDataSent);
  
  // Register peer
  memcpy(peerInfo.peer_addr, broadcastAddress, 6);
  peerInfo.channel = 0;  
  peerInfo.encrypt = false;
  
  // Add peer        
  if (esp_now_add_peer(&peerInfo) != ESP_OK){
    Serial.println("Failed to add peer");
    return;
  }
  // Register for a callback function that will be called when data is received
  esp_now_register_recv_cb(OnDataRecv);
}
 
void loop() {
  xi=random(0,5);
  yi=random(0,100);
 
  // Set values to send
  Enviado.x = xi;
  Enviado.y = yi;
 

  // Send message via ESP-NOW
  esp_err_t result = esp_now_send(broadcastAddress, (uint8_t *) &Enviado, sizeof(Enviado));
   
  if (result == ESP_OK) {
    Serial.println("Sent with success");
    Serial.println("xslave=");
    Serial.print(xii);
    Serial.println("yslave=");
    Serial.print(yii);
  }
  else {
    Serial.println("Error sending the data");
  }
  delay(2000);
}

