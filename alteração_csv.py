import pandas as pd
import csv
from datetime import datetime
from time import sleep
import time

while 1:

    now=datetime.now()
    act_time = now.strftime("%H:%M:%S")
         
    print(act_time)
    sleep(1)

    if act_time == "15:37:00":

        # ler ficheiro csv com novas informações
        df = pd.read_csv("c:/tmp/teste.csv",encoding='latin1',delimiter=';')

        col = df.columns

        # retirar a coluna de nomes, números e categoria
        nome = df['Nome']
        num = df['N¼ BPU']
        codigo = df['Cd.Categoria']

        main_col = ['Num',
                    'Nome',
                    'Codigo']


        main = pd.DataFrame(columns=['Num', 'Nome', 'Codigo'])
        main['Num'] = num
        main['Nome'] = nome
        main['Codigo'] = codigo



        print(act_time)

        nome_file = now.strftime("%Y-%m-%d")
        print(nome_file)

        main.to_excel('c:/tmp/BASE_DADOS_' + nome_file + '.xlsx')







