   M S B A M L   `   `   `  ����J  FStacjaBenzynowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StacjaBenzynowaStacjaBenzynowa  5   	   %    StacjaBenzynowa.Invoices_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StacjaBenzynowa     5   	     � Title$  Faktury��5   	   $	��450��6   $	��800��6&    � 
ResizeMode$ CanMinimize=�62   .��5	      � 
�������.+�5   
   �� -   5         ��Name$ invoiceListView��5   (   $y�Visible=�6   $��10,10,10,51q�5      $��Disabled=�5      $��1��6I   
���   �
���   ���5   )   Z� ��5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   $��Disabled=�68   .+�5      �� $��20(�6;   
���  ��$��WrapWithOverflow=�6Z   $��Copperplate Gothic Bold)�6z   ��6$   �� *email+6z   �� 5      $��15(�6`   $��Italic$�6n   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   ��  �� Path$ 
CouponUsed� �� StringFormat$ 
Kupon: {0}��6�   �� 5      $�� ��6$   �� 5      $��15(�6f   $��Italic$�6t   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ 
BenzynaE95�$ Benzyna E95: {0}��6�   �� 5      $��15(�6f   $��Italic$�6t   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ 
BenzynaE98�$ Benzyna E98: {0}��6�   �� 5      $��15(�6h   $��Italic$�6v   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ 
OlejNapowy�$ Olej Napędowy: {0}��6�   �� 5      $��15(�6W   $��Italic$�6e   $
��Wrap=�6x   $��Copperplate Gothic Bold)�6�   ��6$   �� $	 LPG�$ LPG: {0}��6�   �� 5      $��15(�6g   $��Italic$�6u   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ Standardowe�$ Standardowe: {0}��6�   �� 5      $��15(�6b   $��Italic$�6p   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ Zwoskiem�$ Z woskiem: {0}��6�   �� 5      $�� ��6$   �� 5      $��15(�6_   $��Italic$�6m   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ 
TotalPrice�$ 	Cena: {0}��6�   5      5      5       �� 5"   
   -   5         ��Name$ back_button��5"      $��Wróć��6'   $
��Left=�66   $��
10,389,0,0q�5#      $	��Top=�6!   $��60��69   
���   �$��Copperplate Gothic Bold)�5$       $��16(�6E   $
��Bold"�6S   ��5#   D   Z� ��6Z   Z� 5$   e   5&      5'      