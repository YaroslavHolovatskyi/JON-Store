import {Component, OnInit} from '@angular/core'

@Component({
selector:'app-prod',
templateUrl:'./product.component.html',
styleUrls:['./product.component.scss']
})
export class ProductComponent implements OnInit{
    id="id"
    photo="https://lideropta.com.ua/image/catalog/seo/smartband.png"
    name1="Name"
    description="Description"
    count='Count'
    price="Price"
    creation_date="Creation date"

    ngOnInit(){

    }
    toogle=false
    editForm()
    {
    this.toogle=!this.toogle
    }
}