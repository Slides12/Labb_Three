   M S B A M L   `   `   `  ����L  HQuiz Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Quiz_Configurator.ViewQuiz_Configurator.View  5      *    $Quiz_Configurator.View.EndScreenView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:Quiz_Configurator.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $��0��6   $	��Top=�6"   .+�5      �� $��
Highscore:��6   $��40��5      $��Center=�5      $��20(�5      �� 5      .@�5      �� $
��3000��6   5      5      �� 5   
   $��Center=�6   $��Bottom=�62   $��2��6M   .+�5   
   �� .+�5      �� $��20(�6    �� TextAlignment$ Center=�6&   �� 5   
   $�You anwered ��6    �� 5    
   �6   �� *PlayerViewModel.Points+ �� 5!   
   $� correctly out of ��6    �� 5"   
   �6   �� **(PlayerViewModel.CurrentAmountOfQuestions+ �� 5#   
   $�
 possible.��6   5$      5%      �� 5'   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   .+�5(      �� $��80��6   $��30��6$   $��10q�60   $��Restart��5)      ��5*      �� *SetPlayerViewCommand+�� 5+      $��80��6   $��30��6$   $��10q�60   $��	Main menu��5,      ��5-      �� *SetConfigViewCommand+5.      50      51      52      