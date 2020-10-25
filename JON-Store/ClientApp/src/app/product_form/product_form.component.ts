import {Component, OnInit} from '@angular/core'
import { ProductComponent } from '../product/product.component'

@Component({
selector:'app-prod-form',
templateUrl:'./product_form.component.html',
styleUrls:['./product_form.component.scss']
})
export class ProductFormComponent implements OnInit{
    id="id"
    photo="https://lideropta.com.ua/image/catalog/seo/smartband.png"
    name="Name"
    description="Description"
    count='Count'
    price="Price"
    creation_date="Creation date"

    ngOnInit(){

    }
    inputData(event:any)
    {
    const value = event.target.value
    this.name=value
    }
}