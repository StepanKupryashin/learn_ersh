   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $>��8Выберите файл для копирования:��6   $��0��69   $��10q�6F   �� 5   
   -   5         ��Name$ filePathTextBox��5      $��1��6+   $��10q�68   �� 5   
   -   5        $��
Обзор��5      $��2��6!   $��10q�6.   6:   �� 5   
   $/��)Укажите целевую папку:��6   $��3��61   $��10q�6>   �� 5   
   -   5        $ destinationFolderTextBox��5      $��4��64   $��10q�6A   �� 5   
   $9��3Новое имя файла (по желанию):��6   $��5��68   $��10q�6E   �� 5   
   -   5        $ newFileNameTextBox��5      $��6��6.   $��10q�6;   �� 5   
   -   5        $��Копировать��5      $��7��6&   $��10q�63   6?   5      5      