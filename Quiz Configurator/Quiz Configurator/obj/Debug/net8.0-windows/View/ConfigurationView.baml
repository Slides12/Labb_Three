   M S B A M L   `   `   `  ����L  HQuiz Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Configurator.ViewQuiz_Configurator.View  5      .    (Quiz_Configurator.View.ConfigurationView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Quiz_Configurator.View     5        � DataContext  5      �� *ConfigurationViewModel+.��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $
��Bold"�5      $
��Left=�5      $��Center=�5      ��5      ��  �� Path$ ActivePack.Name�5      �� 5    
   $��Right=�6    �� Orientation$ 
Horizontal=�5!      $��0��5"      .+�5$      �� $��15��6   $��15��5%      $��Right=�5&      $��Center=�5'      $��1��5(      $��5q�5)      �� 5*      $��15��6   $��15��5+      $��Right=�5,      $��Center=�5-      $��1��5.      �� 50      $��15��6   $��15��51      $��Right=�52      $��Center=�53      $��1��54      $��5q�55      57      �� 5:   
   $��1��6   $��5q�5;      $��1q�5<      $��9��5=      5?      �� 5F   
   $��1��6   $��1��5G      $��	Question:��5H      $
��Bold"�5I      $��20 0 q�5J      �� 5L   
   $��2��6   $��1��6    �� AcceptsReturn$
 True��5M      $��
20 0 20 20q�5N      �� 5S   
   $��3��6   $��2��5T      $��	20 0 20 0q�5U      $��4��5V      .+�5X      �� .+�5Y      �� $��Correct Answer:��6   $
��Bold"�5Z      �� 5[      5\      �� 5^      .+�5_      �� $��First Incorrect Answer:��6   $
��Bold"�5`      �� 5a      5b      �� 5d      .+�5e      �� $��Second Incorrect Answer:��6   $
��Bold"�5f      �� 5g      5h      �� 5j      .+�5k      �� $��Third Incorrect Answer:��6   $
��Bold"�5l      �� 5m      5n      5q      5r      5s      