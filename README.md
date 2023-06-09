# Описание приложения 

Данное приложение разработано на C# ASP .NET Core MVC и предназначено для отображения текущей погоды в выбранном городе. 

## Функциональность приложения

* Отображение текущей температуры, влажности, скорости ветра 
* Отображение иконки погодных условий

## Технические особенности

* Для получения данных о погоде и отображения иконок погодных условий используется [API OpenWeatherMap](https://openweathermap.org/), которое предоставляет информацию о погоде для любой точки на земле
* Взаимодействие с API осуществляется при помощи библиотеки `HttpClient`

## Инструкция по запуску

Для запуска приложения необходимо выполнить следующее действие:

* В файле `appsettings.json` в поле `tokenWeather` ввести токен, полученный на сайте [API OpenWeatherMap](https://openweathermap.org/).

## Главная страница сайта
<div align="center">
<image src=".\Images\Main Window Image.PNG">
<image src=".\Images\Weather Response.PNG">
</div>