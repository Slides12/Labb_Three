   M S B A M L   `   `   `  ����L  HQuiz Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Quiz_ConfiguratorQuiz_Configurator  5   	   ?$clr-namespace:Quiz_Configurator.ViewQuiz_Configurator.View  67   "    Quiz_Configurator.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Quiz_Configurator     5   	   5view$clr-namespace:Quiz_Configurator.View     67     � Title$  Quiz Configurator��5   	   $	��500��6#   $	��800��60   $	��450��6<   $	��700��6L    � Icon$ /Assets/icon.ico��6[   
������� J� InputBindings 5	      �� 5
   
   
 �� Key$ P��6    �� 	Modifiers$
 Ctrlf�6    �� Command 6.   �� *SetPlayerViewCommand+�� 5   
   $ E��6   $
 Ctrlf�6    6.   �� *SetConfigViewCommand+�� 5   
   $ Insert��6    6#   �� *+)ConfigurationViewModel.NewQuestionCommand+�� 5   
   $ Delete��6    6#   �� *.,ConfigurationViewModel.DeleteQuestionCommand+�� 5   
   $ O��6   $
 Ctrlf�6    6.   �� *+)ConfigurationViewModel.PackOptionsCommand+�� 5   
   $ F4��6   $	 Altf�6    6.   �� *ExitCommand+�� 5   
   $ I��6   $
 Ctrlf�6    6.   �� *ImportMenuCommand+�� 5   
   $ Return��6   $	 Altf�6"    62   �� *FullscreenCommand+.��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5       $��* �6   .+�5$   
   %   Quiz_Configurator.View.MenuView  .   (Quiz_Configurator.View.ConfigurationView  5%   
   $��1��6!   y�5&   !   �� *DataContext.ConfigVisibility+ �� RelativeSource ��  �� AncestorType
 Window'   !Quiz_Configurator.View.PlayerView  5)   
   $��1��6   y�6'   �� *PlayerVisibility+*   $Quiz_Configurator.View.EndScreenView  5+   
   $��1��6   y�6*   �� *EndScreenVisibility+)   #Quiz_Configurator.View.UserNameView  5-   
   $��1��6   53      54      