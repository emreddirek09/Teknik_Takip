<%@ Page Title="" Language="C#" MasterPageFile="~/default.Master" AutoEventWireup="true" CodeBehind="WebForm13.aspx.cs" Inherits="TeknikTakip.WebForm13" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class=" col col-lg-12">
        <div class="row  text-center">
            <h2>Yeni Kayıt</h2>
        </div>

            </div>
    <div>
        <label for="müsteri" class="col-md-2">Stok Kodu Seç  </label>
        <div class="col-md-9">
            <asp:DropDownList ID="DropDownList1" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1" AutoPostBack="true"  CssClass="form-control" runat="server" Height="50px" Width="250">
                <asp:ListItem  Value="">Seçiniz</asp:ListItem>
            </asp:DropDownList>
        </div>       
    </div>

    <div>
        <label class="col-md-2">Stok Adı  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="stok_adi" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <label class="col-md-2">Birim </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="birim" runat="server"  ReadOnly="true"></asp:TextBox>
            </div>
        </div>
    </div>

    <div>
        <label class="col-md-2">Stok Tip Adı  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="stok_tip_adi" runat="server" ReadOnly="true"></asp:TextBox>
        </div>
        <div>
            <label for="password" class="col-md-2">Cinsi</label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="cinsi" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div>
        <label class="col-md-2">Tür  </label>
        <div class="col-md-9">
            <asp:TextBox class="form-control bg-danger" ID="tür" runat="server" ></asp:TextBox>

        </div>
        <div>
            <label for="password" class="col-md-2">Renk </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="renk" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div>
        <label class="col-md-2">Fiyat</label>
        <div class="col-md-9">
            <input class="form-control" runat="server" id="fiyat">
        </div>
        <div>
            <label for="password" class="col-md-2"> Adet : </label>
            <div class="col-md-9">
                <asp:TextBox class="form-control bg-danger" ID="adet" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
        <div>
            <label for="password" class="col-md-2">Alım Yeri </label>
            <div class="col-md-9">                
                    <asp:TextBox class=" container form-control" ID="alim_yeri" runat="server"></asp:TextBox>                
            </div>
        </div>
    
    <div class="row">
        <div class=" col col-lg-12">
            <div class=" col col-lg-12">
                <asp:Button ID="kayit" class="btn btn-info text-center" Height="30px" Width="200" runat="server" Text="Kayıt" OnClick="kayit_Click" />

            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenfield_bakim" runat="server"></asp:HiddenField>

     <div class="col-xs-12">
        <!--Burada da butona tıklayınca gelecek olan  Bootstrap modal ı ekliyoruz -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog"
            aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">

                    <div class="form-group">
                        <label>Kime Verildi </label>
                        <input id="kime_verildi_popup" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label>Kullanıldığı Yer :</label>
                        <input id="kullanildigi_yer_popup" runat="server" type="text" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label for="tentacles">Kaç Adet :</label>
                        <input class="form-control" runat="server" type="number" id="kac_adet_popup" name="tentacles" min="0" max="9999">
                    </div>

                    <asp:Button ID="stok_cikar_PopUp" class="btn btn-info te" Height="40px" Width="200" runat="server" Text="Gönder" OnClick="stok_cikar_PopUp_Click"></asp:Button>

                </div>

            </div>
        </div>
    </div>
    
    <div class="col-xs-12">
        <asp:Label ID="id" runat="server"></asp:Label>
        <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
                <table class="table table-striped table-bordered table-hover text-center">
                    <thead>

                        <th class="  text-center bg-secondary text-white">Seç</th>
                        <th class="  text-center bg-secondary text-white">Id</th>
                        <th class="  text-center bg-secondary text-white">Stok Bilgileri</th>
                        <th class=" text-center  bg-secondary text-white">Cinsi</th>
                        <th class=" text-center  bg-secondary text-white">Tür </th>
                        <th class=" text-center  bg-secondary text-white">Renk</th>
                        <th class=" text-center  bg-secondary text-white">Adet</th>                        
                        <th class=" text-center  bg-secondary text-white">Fiyat</th>
                        <th class=" text-center  bg-secondary text-white">Alım Yeri</th>
                        <th class=" text-center  bg-secondary text-white">Kayit Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Güncelleme Tarihi</th>
                        <th class=" text-center  bg-secondary text-white">Güncelle / Sil / Çıkar</th>

                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tbody>
                    <tr>
                        <td>
                            <asp:LinkButton ID="sec" runat="server" OnClick="sec_Click" CommandArgument='<%#Eval("Id") %>'>✓</asp:LinkButton>
                        </td>
                        <td>
                            <%#Eval("Id") %>
                        </td>
                        <td>
                            <%#Eval("Stok_Kodu") %> - <%#Eval("Stok_Adi") %> - <%#Eval("Birim") %> - <%#Eval("Stok_Tip_Adi") %>
                        </td>
                        <td>
                           <%#Eval("cinsi") %>
                        </td>
                        <td>
                            <%#Eval("tür") %>
                        </td>
                        <td>
                            <%#Eval("renk") %>
                        </td>
                        <td>
                             <%#Eval("adet") %>
                        </td>
                        <td> 
                            <%#Eval("fiyat") %>
                        </td>
                        <td>
                           <%#Eval("alim_yeri") %>
                        </td>
                         <td>
                           <%#Eval("kayit_tarihi") %>
                        </td>
                        <td>
                           <%#Eval("güncelleme_tarihi") %>
                        </td>
                        <td>
                            <asp:LinkButton ID="Güncelle" title="Güncellemek İçin Tıklayınız" CssClass="fa fa-refresh" runat="server" OnClick="Güncelle_Click1"></asp:LinkButton>
                            &nbsp;
                           &nbsp;
                            &nbsp;
                            &nbsp;
                            <asp:LinkButton ID="sil" runat="server" title="Silmek İçin Tıklayınız" CssClass="fa fa-trash text-danger text" OnClick="sil_Click" OnClientClick="return confirm('Silmek istiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>
                            &nbsp;
                            &nbsp;
                            &nbsp;
                            &nbsp;
                             <asp:LinkButton ID="stok_cikar" CssClass="fa fa-close" runat="server" OnClick="stok_cikar_Click1" OnClientClick="return confirm('Stok Düşmek İstiyormusunuz ?')" CommandArgument='<%#Eval("Id") %>'></asp:LinkButton>

                        </td>

                    </tr>
                </tbody>
            </ItemTemplate>

            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
        </div>

        
        <asp:HiddenField ID="stok_id_hiddenfield" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="ürün_adi_hiddenfield1" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="önceki_ürün_adet_HiddenField1" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="sec_id_HiddenField1" runat="server" />
    
        <asp:HiddenField ID="cinsi_HiddenField1" runat="server"></asp:HiddenField>

        <asp:HiddenField ID="tür_adet_HiddenField1" runat="server"></asp:HiddenField>
        <asp:HiddenField ID="renk_HiddenField1" runat="server"></asp:HiddenField>
         <script type="text/javascript">
        function Gonder() {
            $('#myModal').modal('show');

        }
    </script>
</asp:Content>
